using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorter.emulator.core
{
    public interface IEmulatorCore
    {
        Task Start();
        Task Stop();
    }
}
