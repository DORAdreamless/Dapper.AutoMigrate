using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiantianquan.Common.Configurations;
using Tiantianquan.Common.Runtime.Session;

namespace Tiantianquan.Common.Configurations
{
  public static partial  class ConfigurationExtensions
    {
        public static Configuration UseAbpSession(this Configuration configuration)
        {
            configuration.SetDefault<IAbpSession, ClaimsAbpSession>();
            return configuration;
        }
    }
}
