using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.Services.Interfaces;
using log4net;
using Microsoft.Owin.Host.HttpListener;
using Microsoft.Owin.Hosting;

namespace eds.sorter.emulator.web
{
    public class WebService:IWebService
    {
        private readonly List<IService> _services;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public WebService(List<IService> services)
        {
            _services = services;
        }

        public void Start()
        {
            Trace.TraceInformation(typeof(OwinHttpListener).FullName);
            string baseAddress = "http://+:9000/";
            var startup = new Startup(_services);
            
            // Start OWIN host
            WebApp.Start(baseAddress, builder =>
            {
                startup.Configuration(builder);
            });
        }

        public void Stop()
        {
            
        }
    }
}
