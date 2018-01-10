using Autofac;
using Autofac.Extras.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Autofac;
using Tiantianquan.Common.Dependency;

namespace Tiantianquan.Common.Configurations
{
    public static partial class ConfigurationExtensions
    {
        public static Configuration UseTransactionInterceptor(this Configuration configuration,params Assembly[] assemblies)
        {
            ((AutofacObjectContainer)ObjectContainer.Current).ContainerBuilder.RegisterType<TransactionScopeInterceptor>().SingleInstance();
            foreach (Assembly assembly in assemblies)
            {
                var types = assembly.GetTypes().Where(x => x.IsDefined(typeof(ComponentAttribute), true)).ToArray();
                ((AutofacObjectContainer)ObjectContainer.Current).ContainerBuilder.RegisterTypes(types).SingleInstance().EnableClassInterceptors();
            }
            
            return configuration;
        }
    }
}
