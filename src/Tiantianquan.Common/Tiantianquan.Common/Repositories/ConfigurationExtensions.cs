using Autofac;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Autofac;
using Tiantianquan.Common.Dependency;
using Tiantianquan.Common.Repositories;

namespace Tiantianquan.Common.Configurations
{
    public static partial class ConfigurationExtensions
    {

        public static Configuration RegisterRepositoriesAssembly(this Configuration configuration, params Assembly[] assemblies)
        {
            configuration.repositoryAssemblies.AddRange(assemblies);
            return configuration;
        }
        public static Configuration UseRepositories(this Configuration configuration, string connectionSection, params Assembly[] assemblies)
        {
            configuration.RegisterRepositoriesAssembly(assemblies);
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionSection].ConnectionString;
            string providerName = System.Configuration.ConfigurationManager.ConnectionStrings[connectionSection].ProviderName;
            IPersistenceConfigurer configurer = null;
            switch (providerName)
            {
                case "System.Data.SqlClient":
                    configurer = MsSqlConfiguration.MsSql2008.ConnectionString(connectionString)
                                  .AdoNetBatchSize(500)
                                  .Dialect<NHibernate.Dialect.MsSql2008Dialect>()
                                  .FormatSql()
                                  .ShowSql()
                                  .UseOuterJoin();
                    break;
                case "MySql.Data.MySqlClient":
                    configurer = MySQLConfiguration.Standard.ConnectionString(connectionString)
                                  .AdoNetBatchSize(500)
                                  .Dialect<NHibernate.Dialect.MySQL55InnoDBDialect>()
                                  .FormatSql()
                                  .ShowSql()
                                  .UseOuterJoin();
                    break;
            }

            NhSessionFactory.Instance(configurer, configuration.repositoryAssemblies.ToArray());
            Engine.RegisterDataBase(providerName, connectionString);


            foreach (Assembly assembly in configuration.repositoryAssemblies)
            {
                Type[] types = assembly.GetTypes().Where(item => typeof(IRepository).IsAssignableFrom(item) && !item.IsAbstract).ToArray();
                ((AutofacObjectContainer)ObjectContainer.Current).ContainerBuilder.RegisterTypes(types).AsImplementedInterfaces().SingleInstance();
            }
            return configuration;
        }
        //public static Configuration RegisterDomainAssembly(this Configuration configuration, params Assembly[] assemblies)
        //{
        //    configuration.domainAssemblies.AddRange(assemblies);
        //    return configuration;
        //}
        public static Configuration RunAsync(this Configuration configuration, params Assembly[] assemblies)
        {

            Engine.RunSync(configuration.repositoryAssemblies.ToArray());
            return configuration;
        }
    }
}
