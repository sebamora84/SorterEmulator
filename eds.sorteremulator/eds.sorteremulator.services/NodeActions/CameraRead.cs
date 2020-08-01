using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;
using eds.sorteremulator.services.Services.Interfaces;

namespace eds.sorteremulator.services.NodeActions
{
    public class CameraRead: INodeAction
    {
        private readonly IParcelService _parcelsService;
        

        public CameraRead(IParcelService parcelsService)
        {
            _parcelsService = parcelsService;
        }

        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            var parcel = _parcelsService.GetParcel(tracking.Pic);
            parcel.Barcode = $"{parcel.BarcodeToRead}";
            return false;
        }
    }
}
