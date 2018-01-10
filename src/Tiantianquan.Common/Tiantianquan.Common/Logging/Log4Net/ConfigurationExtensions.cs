using Tiantianquan.Common.Logging.Log4Net;
using Tiantianquan.Common.Logging;

namespace Tiantianquan.Common.Configurations
{
    /// <summary>ENode configuration class Autofac extensions.
    /// </summary>
    public static partial class ConfigurationExtensions
    {
        /// <summary>Use Log4Net as the logger.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseLog4Net(this Configuration configuration)
        {
            return UseLog4Net(configuration, "log4net.config");
        }
        /// <summary>Use Log4Net as the logger.
        /// </summary>
        /// <returns></returns>
        public static Configuration UseLog4Net(this Configuration configuration, string configFile, string loggerRepository = "NetStandardRepository")
        {
            configuration.SetDefault<ILoggerFactory, Log4NetLoggerFactory>(new Log4NetLoggerFactory(configFile, loggerRepository));
            return configuration;
        }
    }
}