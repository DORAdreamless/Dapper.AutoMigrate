using System;
using Tiantianquan.Common.Dependency;
using Tiantianquan.Common.Logging;

namespace Tiantianquan.Common.Configurations
{
    public partial class Configuration
    {
        /// <summary>Provides the singleton access instance.
        /// </summary>
        public static Configuration Instance
        {
            get
            {
                return new Configuration();
            }
        }

        private Configuration() { }



        public Configuration SetDefault<TService, TImplementer>(string serviceName = null, LifeStyle life = LifeStyle.Singleton)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.Register<TService, TImplementer>(serviceName, life);
            return this;
        }
        public Configuration SetDefault<TService, TImplementer>(TImplementer instance, string serviceName = null)
            where TService : class
            where TImplementer : class, TService
        {
            ObjectContainer.RegisterInstance<TService, TImplementer>(instance, serviceName);
            return this;
        }

        public Configuration RegisterCommonComponents()
        {
            SetDefault<ILoggerFactory, EmptyLoggerFactory>();
            return this;
        }
        public Configuration RegisterUnhandledExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var logger = ObjectContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
                logger.ErrorFormat("Unhandled exception: {0}", e.ExceptionObject);
            };
            return this;
        }
        public Configuration BuildContainer()
        {
            ObjectContainer.Build();
            return this;
        }
    }
}
