using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Tiantianquan.Common.Autofac;
using Tiantianquan.Common.Dependency;

namespace Tiantianquan.Common.Configurations
{
   public static partial class ConfigurationExtensions
    {
        public static Configuration UseWebApi(this Configuration configuration, HttpConfiguration config, params Assembly[] assemblies)
        {
            var builder = ((AutofacObjectContainer)ObjectContainer.Current).ContainerBuilder;



            // Register your Web API controllers.
            builder.RegisterApiControllers(assemblies);

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            ObjectContainer.Current.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(((AutofacObjectContainer)ObjectContainer.Current).Container);
            //var container = builder.Build();
           // config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return configuration;
        }
    }
}
