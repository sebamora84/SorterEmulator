﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eds.sorteremulator.services.Model;

namespace eds.sorteremulator.services.Services.Interfaces
{
    public interface IParcelService : IService
    {
        List<Parcel> GetAllParcels();
        Parcel AddNewParcel(Node entryPoint, string barcodeToRead = "1   0", int weightToWeigh = 0);
        void UpdateParcels(decimal sorterSpeed);
        Parcel GetParcel(int messagePic);
        void RemoveParcel(int pic);
    }
}