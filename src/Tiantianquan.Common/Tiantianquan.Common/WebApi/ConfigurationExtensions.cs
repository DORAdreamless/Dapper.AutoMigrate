using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using Tiantianquan.Common.Autofac;
using Tiantianquan.Common.Dependency;

namespace Tiantianquan.Common.Configurations
{
   public static partial class ConfigurationExtensions
    {
        public static Configuration RegisterWebApiAssembly(this Configuration configuration, params Assembly[] assemblies)
        {
            configuration.webapiAssemblies.AddRange(assemblies);
            return configuration;
        }

        public static Configuration UseWebApi(this Configuration configuration, HttpConfiguration config, params Assembly[] assemblies)
        {
            configuration.webapiAssemblies.AddRange(assemblies);

            var builder = ((AutofacObjectContainer)ObjectContainer.Current).ContainerBuilder;

            // Register your Web API controllers.
            builder.RegisterApiControllers(configuration.webapiAssemblies.ToArray());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            //MVC

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(configuration.webapiAssemblies.ToArray());

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(configuration.webapiAssemblies.ToArray());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            // OPTIONAL: Enable action method parameter injection (RARE).
           // builder.InjectActionInvoker();


            ObjectContainer.Current.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(((AutofacObjectContainer)ObjectContainer.Current).Container);
            //var container = builder.Build();
            // config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(((AutofacObjectContainer)ObjectContainer.Current).Container));
            return configuration;
        }
    }
}
