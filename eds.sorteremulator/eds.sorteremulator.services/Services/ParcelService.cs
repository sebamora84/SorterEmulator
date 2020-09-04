using eds.sorteremulator.services.Configurations.Nodes;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.Services.Interfaces;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace eds.sorteremulator.services.Services
{
    public class ParcelService : IParcelService
    {

        #region emulator

        private int _lastEmulatorPic;
        private readonly ConcurrentDictionary<int, Parcel> _parcels = new ConcurrentDictionary<int, Parcel>();


        public void Start()
        {
            
        }

        public void Stop()
        {

        }

        public List<Parcel> GetAllParcels()
        {
            return _parcels.Values.ToList();
        }

        public Parcel AddNewParcel(NodeConfig entryPoint, string scannerData1, string scannerData2, string scannerData3, string scannerData4, string scannerData5)
        {

            var package = new Parcel
            {
                Pic = GetNextEmulatorPic(),
                HostPic = -1,
                HostData = "",
                EntryNode = entryPoint.Name,
                ScannerDataToRead1 = scannerData1,
                ScannerDataToRead2 = scannerData2,
                ScannerDataToRead3 = scannerData3,
                ScannerDataToRead4 = scannerData4,
                ScannerDataToRead5 = scannerData5,
            };
            _parcels.TryAdd(package.Pic, package);
            return package;
        }

        public void UpdateParcels(decimal sorterSpeed)
        {
            
        }

        public Parcel GetParcel(int pic)
        {
            _parcels.TryGetValue(pic, out var parcel);
            return parcel;
        }

        public void RemoveParcel(int pic)
        {
            _parcels.TryRemove(pic, out var parcel);
        }

        private int GetNextEmulatorPic()
        {
            return Interlocked.Increment(ref _lastEmulatorPic) % 10000;
        }

        #endregion


    }
}
    



