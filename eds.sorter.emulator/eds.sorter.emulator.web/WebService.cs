using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.logger;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.web.Configuration;
using log4net;
using Microsoft.Owin.Host.HttpListener;
using Microsoft.Owin.Hosting;

namespace eds.sorter.emulator.web
{
    public class WebService:IWebService
    {
        private readonly List<IService> _services;
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static WebServiceConfig WebServiceConfig
        {
            get => ConfigurationManager.GetConfig<WebServiceConfig>();
            set => ConfigurationManager.SaveConfig(value);
        }
        public WebService(List<IService> services)
        {
            _services = services;
        }

        public void Start()
        {

            _log.Info($"WebServer is starting at port {WebServiceConfig.Port}");
            Trace.TraceInformation(typeof(OwinHttpListener).FullName);
            string baseAddress = $"http://+:{WebServiceConfig.Port}/";
            var startup = new Startup(_services);
            try
            {
                WebApp.Start(baseAddress, builder =>
                {
                    startup.Configuration(builder);
                });
            }
            catch (Exception e)
            {
                _log.Error($"Could not start WebServer. Did you executed \"netsh http add urlacl url=http://+:{WebServiceConfig.Port}/ user=Everyone\"?", e);
            }
            // Start OWIN host
           
        }

        public void Stop()
        {
            
        }
    }
}
