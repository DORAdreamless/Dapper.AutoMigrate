using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Mapping;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Engine.RegisterDataBase("System.Data.SqlClient", "server=.;uid=sa;pwd=123;database=nop;");
            Engine.RunSync();

            Console.Read();
        }


    }

    public class User
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string UserName { get; set; }
        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime UpdatedAt { get; set; }
        public virtual DateTime? DeletedAt { get; set; }

    }


    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            this.Id(item => item.Id).GeneratedBy.Assigned();
            this.Map(item => item.Name);
            this.Map(item => item.UserName).Unique();
            this.Map(item => item.CreatedAt).Insert().Index("idx_user_created_at");
            this.Map(item => item.UpdatedAt).Update();
            this.Map(item => item.DeletedAt).Index("idx_user_deleted_at");
        }
    }

    public class Engine
    {
        protected static string ConnectionString;
        private static string ProviderInvariantName;





        public static IDbConnection GetDbConnection()
        {
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(ProviderInvariantName);
            DbConnection dbConnection = dbProviderFactory.CreateConnection();
            dbConnection.ConnectionString = ConnectionString;
            return dbConnection;
        }

        public static void RegisterDataBase(string providerInvariantName, string connectionString)
        {
            Engine.ProviderInvariantName = providerInvariantName;
            Engine.ConnectionString = connectionString;
        }

        public static void RunSync()
        {
            IPersistenceConfigurer configurer = MsSqlConfiguration.MsSql2012.ConnectionString(Engine.ConnectionString)
                .FormatSql()
                .ShowSql();
            Fluently.Configure()
                    .Database(
                      configurer
                    )
                    .Mappings(c=>c.FluentMappings.AddFromAssembly(typeof(User).Assembly))
                    .ExposeConfiguration(cfg=>new SchemaUpdate(cfg).Execute(true,true))
                    .BuildSessionFactory();
        }
    }
}
