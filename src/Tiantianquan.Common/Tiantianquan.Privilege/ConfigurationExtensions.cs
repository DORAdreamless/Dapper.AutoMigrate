using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Privilege.Domain;

namespace Tiantianquan.Common.Configurations
{
    public static partial class ConfigurationExtensions
    {
        public static Configuration UsePrivilege(this Configuration configuration)
        {
            Assembly assembly = typeof(ApplicationUser).Assembly;
            configuration.RegisterApplicationAssembly(assembly);
            configuration.RegisterDomainAssembly(assembly);
            configuration.RegisterWebApiAssembly(assembly);
            configuration.RegisterRepositoriesAssembly(assembly);
            return configuration;
        }
    }
}
