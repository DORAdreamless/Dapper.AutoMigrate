using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Logging;

namespace Tiantianquan.Common.Repositories
{
    public   class NhSessionFactory
    {

        private static ISessionFactory sessionFactory = null;

        #region 初始化 生成SessionFactory，并配置上下文策略
        public static void Instance(IPersistenceConfigurer configurer, params Assembly[] assemblies)
        {

            if (sessionFactory != null)
            {
                return;
            }

            Configuration config = new Configuration();
            config.SetNamingStrategy(DefaultNamingStrategy.Instance);
            config = Fluently.Configure(config)
                .Database(configurer)
                .Mappings(m =>
                {
                    foreach (var assembly in assemblies)
                    {
                        m.FluentMappings.AddFromAssembly(assembly);
                    }

                })
                .CurrentSessionContext<WebSessionContext>()
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute((sql)=> {
                    ILogger logger = new Tiantianquan.Common.Logging.Log4Net.Log4NetLoggerFactory("log4net.config").Create("NhSessionFactory");
                    logger.Info(sql);
                }, true))
                .BuildConfiguration();
            sessionFactory = config.BuildSessionFactory();


        }
        #endregion

        #region Session在当前上下文的操作
        private static void BindContext()
        {
            if (!CurrentSessionContext.HasBind(sessionFactory))
            {
                CurrentSessionContext.Bind(sessionFactory.OpenSession());
            }
        }

        private static void UnBindContext()
        {
            if (CurrentSessionContext.HasBind(sessionFactory))
            {
                CurrentSessionContext.Unbind(sessionFactory);
            }
        }

        public static void CloseCurrentSession()
        {
            if (sessionFactory.GetCurrentSession().IsOpen)
            {
                sessionFactory.GetCurrentSession().Close();
            }
        }

        public static ISession GetCurrentSession()
        {
            BindContext();
            return sessionFactory.GetCurrentSession();
        }
        #endregion

        #region 关闭SessionFactory（一般在应用程序结束时操作）
        public static void CloseSessionFactory()
        {
            UnBindContext();
            if (!sessionFactory.IsClosed)
            {
                sessionFactory.Close();
            }
        }
        #endregion

        #region 打开一个新的Session
        public static ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }
        #endregion
    }
}
