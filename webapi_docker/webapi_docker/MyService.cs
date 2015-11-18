using System;
using log4net;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Topshelf;
using Topshelf.ServiceConfigurators;
using Topshelf.Runtime;
using Owin;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Autofac;
using Autofac.Integration.Owin;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace webapi_docker
{
	public class MyOwinService 
	{
		private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private IDisposable _webServer { get; set; }

		public MyOwinService()
		{
			
		}

		public bool Start() 
		{

            string baseUri = "http://*:8080";
            _webServer = WebApp.Start<Startup>(url: baseUri);
            Console.WriteLine("Loaded webserver at address={0}", baseUri);
            Console.WriteLine("I'm running on {0} directly from assembly {1}", Environment.OSVersion, System.Reflection.Assembly.GetEntryAssembly().FullName);
            return true;
		}

		public bool Stop() 
		{ 
			_webServer.Dispose ();
			return true;
		}

	}


}

