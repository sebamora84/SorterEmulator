using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using eds.sorter.emulator.configuration;
using eds.sorter.emulator.services.Configurations;
using eds.sorter.emulator.services.Model;
using eds.sorter.emulator.services.NodeActions.Base;
using eds.sorter.emulator.services.Services;
using eds.sorter.emulator.services.Services.Interfaces;
using eds.sorter.emulator.logger;
using log4net;
using Timer = System.Timers.Timer;

namespace eds.sorter.emulator.services.Services
{
    public class ParcelService : IParcelService
    {
        private readonly ILog _log = EmulatorLogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

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

        public Parcel AddNewParcel(Node entryPoint, string barcodeToRead = "1   1", int weightToWeigh = 0)
        {

            var package = new Parcel
            {
                Pic = GetNextEmulatorPic(),
                HostPic = -1,
                HostData = "CREATED",
                EntryNode = entryPoint.Name,
                Barcode = "1   0",
                Weight = "1   0",
                BarcodeToRead = barcodeToRead,
                WeightToWeigh = weightToWeigh
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
    



