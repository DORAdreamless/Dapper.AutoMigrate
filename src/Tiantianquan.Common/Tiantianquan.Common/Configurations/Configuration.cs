using System;
using System.Collections.Generic;
using System.Reflection;
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

        /// <summary>
        /// 仓储实现和ORM映射配置
        /// </summary>
        public List<Assembly> repositoryAssemblies = new List<Assembly>();
        /// <summary>
        /// 业务逻辑实现和事物拦截
        /// </summary>
        public List<Assembly> applicationAssemblies = new List<Assembly>();
        /// <summary>
        /// 领域实体和仓储接口
        /// </summary>
        public List<Assembly> domainAssemblies = new List<Assembly>();
        /// <summary>
        /// webapi提供接口
        /// </summary>
        public List<Assembly> webapiAssemblies = new List<Assembly>();

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
