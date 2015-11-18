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
			const string baseAddress = "http://localhost:10281/";
			_webServer = WebApp.Start<Startup>(url: baseAddress);
			log.DebugFormat("Loaded webserver at address={0}", baseAddress);
			return true;
		}

		public bool Stop() 
		{ 
			_webServer.Dispose ();
			return true;
		}

	}


}

