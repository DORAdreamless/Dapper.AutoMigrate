using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Application;
using Tiantianquan.Common.Autofac;
using Tiantianquan.Common.Dependency;

namespace Tiantianquan.Common.Configurations
{
    public static partial class ConfigurationExtensions
    {
        public static Configuration UseTransactionInterceptor(this Configuration configuration,params Assembly[] assemblies)
        {
            configuration.RegisterApplicationAssembly(assemblies);
            ((AutofacObjectContainer)ObjectContainer.Current).ContainerBuilder.RegisterType<TransactionScopeInterceptor>().SingleInstance();
            foreach (Assembly assembly in configuration.applicationAssemblies)
            {
                var types = assembly.GetTypes().Where(x => typeof(BaseService).IsAssignableFrom(x)&&!x.IsAbstract).ToArray();
                ((AutofacObjectContainer)ObjectContainer.Current).ContainerBuilder.RegisterTypes(types).SingleInstance().EnableClassInterceptors();
            }
            
            return configuration;
        }

        public static Configuration RegisterApplicationAssembly(this Configuration configuration, params Assembly[] assemblies)
        {
            configuration.applicationAssemblies.AddRange(assemblies);
            return configuration;
        }
    }
}
