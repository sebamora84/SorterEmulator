using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Configurations.Nodes;
using eds.sorteremulator.services.Model;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface IParcelService : IService
    {
        List<Parcel> GetAllParcels();
        Parcel AddNewParcel(NodeConfig entryPoint, string scannerData1, string scannerData2, string scannerData3, string scannerData4, string scannerData5);
        void UpdateParcels(decimal sorterSpeed);
        Parcel GetParcel(int messagePic);
        void RemoveParcel(int pic);
    }
}
