using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Model;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface ISorterService : IService
    {
       
        void StartAddTray();
        void StopAddTray();
        void AddMultiRemoteControl(string multiName, int pic, int activateDelay, int deactivateDelay);
    }
}
