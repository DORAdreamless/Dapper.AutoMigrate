using Autofac;
using Tiantianquan.Common.Autofac;
using Tiantianquan.Common.Dependency;

namespace Tiantianquan.Common.Configurations
{
    /// <summary>ENode configuration class Autofac extensions.
    /// </summary>
    public static partial class ConfigurationExtensions
    {
        /// <summary>Use Autofac as the object container.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseAutofac(this Configuration configuration)
        {
            return UseAutofac(configuration, new ContainerBuilder());
        }
        /// <summary>Use Autofac as the object container.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseAutofac(this Configuration configuration, ContainerBuilder containerBuilder)
        {
            ObjectContainer.SetContainer(new AutofacObjectContainer(containerBuilder));
            return configuration;
        }

        
    }
}