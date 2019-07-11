using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorter.emulator.services.Model;

namespace eds.sorter.emulator.services.Services.Interfaces
{
    public interface IPhysicsService : IService
    {
        Tracking AddTracking(int pic, Guid nodeId, decimal position);
        void SetDestination(Guid id,  Guid nodeId);

        List<Tracking> GetAllTracking();
        Tracking GetTracking(Guid id);
        Tracking GetTrackingByPic(int pic);
        void RemoveTracking(Guid id);
        void RemoveTrackingByPic(int pic);
    }
}
