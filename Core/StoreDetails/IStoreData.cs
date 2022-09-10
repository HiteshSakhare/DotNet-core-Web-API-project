using MedicalStoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Core.StoreDetails
{
    public interface IStoreData
    {
        List<StoreModel> GetStoreDetails();
        StoreModel GetStoreDetail(Guid id);
        StoreModel AddStore(StoreModel storeModel);
        void DeleteStore(StoreModel storeModel);
        StoreModel EditStore(StoreModel storeModel);
    }
}
