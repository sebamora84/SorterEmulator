using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Model;

namespace eds.sorter.emulator.services.Services.Interfaces
{
    public interface ISorterService : IService
    {
       
        void StartAddTray();
        void StopAddTray();
        void AddMultiRemoteControl(string multiName, int pic, int delayActivate, int delayDeactivate);
    }
}
