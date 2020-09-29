using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface ISorterService : IService
    {
        public void AddActionDelay(string delayGroup, IManualAction manualAction, ActionConfig actionConfig, int delay);
    }
}
