using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.core;
using eds.sorter.emulator.logger;
using log4net;

namespace eds.sorter.emulator
{
    public class EmulatorService:IEmulatorService
    {
        private EmulatorCore _emulatorCore;

        public async Task OnStart(string[] args)
        {

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            _emulatorCore = new EmulatorCore();
            await _emulatorCore.Start();
        }


        public async Task OnStop()
        {
            await _emulatorCore.Stop();
        }
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType)
                .Fatal("Unhandled exception", e.ExceptionObject as Exception);
        }
    }
}
