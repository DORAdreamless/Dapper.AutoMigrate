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
     

        public static Configuration UseRepositories(this Configuration configuration, string connectionSection, params Assembly[] assemblies)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionSection].ConnectionString;
            string providerName = System.Configuration.ConfigurationManager.ConnectionStrings[connectionSection].ProviderName;
            var configurer = MsSqlConfiguration.MsSql2008.ConnectionString(connectionString)
              .AdoNetBatchSize(500)
              .Dialect<NHibernate.Dialect.MsSql2008Dialect>()
              .FormatSql()
              .ShowSql()
              .UseOuterJoin();
            NhSessionFactory.Instance(configurer, assemblies);
            Engine.RegisterDataBase(providerName, connectionString);
           

            foreach (Assembly assembly in assemblies)
            {
               Type[] types = assembly.GetTypes().Where(item => typeof(IRepository).IsAssignableFrom(item) && !item.IsAbstract).ToArray();
                ((AutofacObjectContainer)ObjectContainer.Current).ContainerBuilder.RegisterTypes(types).AsImplementedInterfaces().SingleInstance();
            }
            return configuration;
        }

        public static Configuration RunAsync(this Configuration configuration, params Assembly[] assemblies)
        {
            Engine.RunSync(assemblies);
            return configuration;
        }
    }
}
