using System;
using Topshelf;
using Topshelf.Autofac;
using Autofac;


namespace webapi_docker
{
	public class Webapi_HostService
	{
		

		public Webapi_HostService()
		{
			

		}

		public static void Main (string[] args)
		{
			var builder = new ContainerBuilder();
			//builder.RegisterType<SampleDependency>().As<ISampleDependency>();
			builder.RegisterType<MyOwinService>();
			var container = builder.Build();


			HostFactory.Run(c =>
				{
					
					c.UseAutofacContainer(container);

					c.Service<MyOwinService>(s =>
						{
							s.ConstructUsingAutofacContainer();
							s.WhenStarted((service, control) => service.Start());
							s.WhenStopped((service, control) => service.Stop());


						});
					c.RunAsNetworkService();
				});
		}
	}
}
