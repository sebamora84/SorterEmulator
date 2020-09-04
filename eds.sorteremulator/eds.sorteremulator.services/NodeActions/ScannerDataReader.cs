using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Model;
using eds.sorteremulator.services.NodeActions.Base;

using eds.sorteremulator.services.Configurations;
using eds.sorteremulator.services.Configurations.Actions;
using eds.sorteremulator.services.Services.Interfaces;
using eds.sorteremulator.services.Configurations.Actions.CustomData;
using eds.sorteremulator.services.Extensions;

namespace eds.sorteremulator.services.NodeActions
{
    public class ScannerDataReader: INodeAction
    {
        private readonly IParcelService _parcelsService;
        

        public ScannerDataReader(IParcelService parcelsService)
        {
            _parcelsService = parcelsService;
        }

        public bool Execute(Tracking tracking, ActionConfig nodeActionConfig)
        {
            var parcel = _parcelsService.GetParcel(tracking.Pic);

            var scannerDataReaderData = nodeActionConfig.GetActionInfo<ScannerDataReaderData>();
            switch (scannerDataReaderData.Number)
            {
                case "1":
                    parcel.ScannerData1 =$"{scannerDataReaderData.Prefix}{parcel.ScannerDataToRead1}{scannerDataReaderData.Sufix}";
                    break;
                case "2":
                    parcel.ScannerData2 = $"{scannerDataReaderData.Prefix}{parcel.ScannerDataToRead2}{scannerDataReaderData.Sufix}";
                    break;
                case "3":
                    parcel.ScannerData3 = $"{scannerDataReaderData.Prefix}{parcel.ScannerDataToRead3}{scannerDataReaderData.Sufix}";
                    break;
                case "4":
                    parcel.ScannerData4 = $"{scannerDataReaderData.Prefix}{parcel.ScannerDataToRead4}{scannerDataReaderData.Sufix}";
                    break;
                case "5":
                    parcel.ScannerData5 = $"{scannerDataReaderData.Prefix}{parcel.ScannerDataToRead5}{scannerDataReaderData.Sufix}";
                    break;
            }
           
            return true;
        }
    }
}
