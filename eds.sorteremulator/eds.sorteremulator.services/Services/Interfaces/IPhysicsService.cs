using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Model;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface IPhysicsService : IService
    {
        Tracking AddTracking(int pic, Guid nodeId, decimal position);
        List<Tracking> GetAllTracking();
        Tracking GetTracking(Guid id);
        Tracking GetTrackingPresentByPic(int pic);
        List<Tracking> GetAllTrackingByPic(int pic);
        void RemoveTracking(Guid id);
        void RemoveTrackingByPic(int pic);
        void ExecuteManualActionConfig(ActionConfig actionConfig);
    }
}
