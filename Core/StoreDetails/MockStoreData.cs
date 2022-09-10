using MedicalStoreManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStoreManagementSystem.Core.StoreDetails
{
    public class MockStoreData : IStoreData
    {
        private List<StoreModel> storeModels = new List<StoreModel>()
        {
            new StoreModel()
            {
                StoreId=Guid.NewGuid(),
                StoreName="Store-1",
                StoreLocation="Pune"
            },
            new StoreModel()
            {
                StoreId=Guid.NewGuid(),
                StoreName="Store-2",
                StoreLocation="Mumbai"
            }
        };
        public StoreModel AddStore(StoreModel storeModel)
        {
            storeModel.StoreId = Guid.NewGuid();
            storeModels.Add(storeModel);
            return storeModel;
        }

        public void DeleteStore(StoreModel storeModel)
        {
            throw new NotImplementedException();
        }

        public StoreModel EditStore(StoreModel storeModel)
        {
            throw new NotImplementedException();
        }

        public List<StoreModel> GetStoreDetails()
        {
            return storeModels;
        }

        public StoreModel GetStoreDetail(Guid Storeid)
        {
            return storeModels.SingleOrDefault(op => op.StoreId == Storeid);
        }
    }
}
