using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eds.sorter.emulator
{
    public interface IEmulatorService
    {
        Task OnStart(string[] args);
        Task OnStop();
    }
}
