using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridgeDataaccess.Repository.Interface
{
    public interface IInventoryRepository
    {
        Task<object> AddInventoryDetails(string inventory);
        Task<object> UpdateInventoryDetails(int item_id,string inventory);
        Task<object> GetItemList();
        Task<object> DeleteInventoryItem(int Item_id);
    }
}
