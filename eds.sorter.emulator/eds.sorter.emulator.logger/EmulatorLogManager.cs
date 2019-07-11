using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace eds.sorter.emulator.logger
{
    public class EmulatorLogManager
    {
        public static ILog GetLogger(Type type)
        {
            return LogManager.GetLogger(type);
        }
    }
}
