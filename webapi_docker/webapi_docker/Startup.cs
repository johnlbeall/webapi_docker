using System;
using Owin;
using Autofac;
using System.Web;
using System.Web.Http;
using Autofac.Integration.Owin;
using WebApiControllers;
using System.Reflection;
using Autofac.Integration.WebApi;
using Swashbuckle.Application;

namespace webapi_docker
{
	class Startup
	{
		//  Hack from http://stackoverflow.com/a/17227764/19020 to load controllers in 
		//  another assembly.  Another way to do this is to create a custom assembly resolver

		// This code configures Web API. The Startup class is specified as a type
		// parameter in the WebApp.Start method.
		public void Configuration(IAppBuilder appBuilder)
		{


			var builder = new ContainerBuilder();
			var config = new HttpConfiguration();
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());


			builder.RegisterType<HelloController>().InstancePerRequest();
			// Register dependencies, then...
			var container = builder.Build();

			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);	

			// Register the Autofac middleware FIRST. This also adds
			// Autofac-injected middleware registered with the container.
			appBuilder.UseAutofacMiddleware(container);

			// ...then register your other middleware not registered
			// with Autofac.
			// Configure Web API for self-host. 


			//  Enable attribute based routing
			//  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

            config.EnableSwagger(c =>
            {
                c.IncludeXmlComments("docs.xml");
                c.SingleApiVersion("1.0", "Owin webapi docker");
            }).EnableSwaggerUi();


            appBuilder.UseWebApi(config);
		} 
	}
}

