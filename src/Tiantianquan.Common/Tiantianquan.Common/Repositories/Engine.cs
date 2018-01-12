using Autofac;
using Dapper;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tiantianquan.Common.Dependency;
using Tiantianquan.Common.Domain;
using Tiantianquan.Common.Logging;

namespace Tiantianquan.Common.Repositories
{
    public class Engine
    {
        protected static string ConnectionString;
        private static string ProviderInvariantName;

        private static List<string> ExtraSqls = new List<string>();

   
        public static IDbConnection GetDbConnection()
        {
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(ProviderInvariantName);
            DbConnection dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = ConnectionString;
            dbConnection.Open();
            return dbConnection;
        }

        public static void RegisterDataBase(string providerInvariantName, string connectionString)
        {
            Engine.ProviderInvariantName = providerInvariantName;
            Engine.ConnectionString = connectionString;
        }

        public static void RunSync(params Assembly[] assemblies)
        {
           


            List<Type> dbEntityTypes = new List<Type>();
            foreach (var assembly in assemblies)
            {
                dbEntityTypes.AddRange(assembly.GetTypes().Where(type => typeof(IBaseEntity).IsAssignableFrom(type) && !type.IsAbstract));
            }
            foreach (var dbEntityType in dbEntityTypes)
            {
                string tableName=DefaultNamingStrategy.Instance.ClassToTableName(dbEntityType.Name);
                string tableDescription = dbEntityType.Name;
                if (dbEntityType.IsDefined(typeof(DescriptionAttribute)))
                {
                    tableDescription = dbEntityType.GetCustomAttribute<DescriptionAttribute>().Description;
                }
                ExtraSqls.Add(string.Format(@"declare @CurrentUser sysname
                                            select @CurrentUser = user_name()
                                            if exists (select * from ::fn_listextendedproperty('MS_Description', 'schema', @CurrentUser, 'table', '{0}', default, default))
                                            BEGIN
                                                exec sys.sp_dropextendedproperty 'MS_Description', 'schema', @CurrentUser, 'table', '{0}'
                                            END
                                            exec sys.sp_addextendedproperty 'MS_Description', '{1}', 'schema', @CurrentUser, 'table', '{0}'
                                            ",tableName,tableDescription));

                foreach (var property in dbEntityType.GetProperties())
                {
                    string columnName = DefaultNamingStrategy.Instance.PropertyToColumnName(property.Name);
                    string columnDescription = property.Name;
                    if (property.IsDefined(typeof(DescriptionAttribute)))
                    {
                        columnDescription = property.GetCustomAttribute<DescriptionAttribute>().Description;
                    }
                    ExtraSqls.Add(string.Format(@"declare @CurrentUser sysname
                                                select @CurrentUser = user_name()
                                                if exists (select * from ::fn_listextendedproperty('MS_Description', 'schema', @CurrentUser, 'table', '{0}', 'column', '{1}'))
                                                BEGIN
                                                    exec sys.sp_dropextendedproperty 'MS_Description', 'schema', @CurrentUser, 'table', '{0}', 'column', '{1}'
                                                END
                                                exec sys.sp_addextendedproperty 'MS_Description', '{2}', 'schema', @CurrentUser, 'table', '{0}', 'column', '{1}'
                                                ",tableName,columnName, columnDescription));
                }
            }
            ILogger logger = ObjectContainer.Current.Resolve<ILoggerFactory>().Create(typeof(Engine));
            foreach (var sql in ExtraSqls)
            {
               
                using (IDbConnection connection = GetDbConnection())
                {
                    
                    try
                    {
                        connection.Execute(sql);
                        
                    }
                    catch(Exception ex)
                    {
                       
                        logger.Error(ex.Message + sql,ex);
                    }
                }
            }
            logger.Info(string.Join("\r\n", ExtraSqls));
        }

        public static void AddForeignKey<T1, T2>(Expression<Func<T1, object>> memberExpression1, Expression<Func<T2, object>> memberExpression2)
            where T1 : IBaseEntity
            where T2 : IBaseEntity
        {
            Regex regex = new Regex(@"Convert\((.*?)\.(.*?)\)", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Multiline);
            string propertyName1 = regex.Match(memberExpression1.Body.ToString()).Groups[2].Value;
            string propertyName2 = regex.Match(memberExpression2.Body.ToString()).Groups[2].Value;
            string tableName1 = DefaultNamingStrategy.Instance.ClassToTableName(typeof(T1).Name);
            string tableName2 = DefaultNamingStrategy.Instance.ClassToTableName(typeof(T2).Name);
            string columnName1 = DefaultNamingStrategy.Instance.PropertyToColumnName(propertyName1);
            string columnName2 = DefaultNamingStrategy.Instance.PropertyToColumnName(propertyName2);
            string foreignkey = string.Format("{0}_{1}_foreignkey_{2}_{3}",
             tableName1,
             columnName1,
             tableName2,
             columnName2
             );
            //string drop1 = string.Format("alter table `{0}` drop foreign key `{1}`;", tableName1, foreignkey);
            //ExtraSqls.Add(drop1);
            //string drop2 = string.Format("alter table `{0}` drop index `{1}` ;", tableName1, foreignkey);
            //ExtraSqls.Add(drop2);
            string drop = string.Format("alter table \"{0}\" drop constraint \"{1}\";", tableName1, foreignkey);
            ExtraSqls.Add(drop);
            string create = string.Format("alter table \"{0}\" add constraint \"{1}\" foreign key (\"{2}\") references \"{3}\" (\"{4}\") on delete no action on update no action",
                tableName1,
                foreignkey,
                columnName1,
                tableName2,
                columnName2
                );
            ExtraSqls.Add(create);
        }
    }
}
