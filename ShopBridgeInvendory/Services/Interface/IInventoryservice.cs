using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopBridgeInvendory.Services.Interface
{
    public interface IInventoryservice
    {
        Task<object> AddInventoryDetails(string jsonString);
        Task<object> UpdateInventoryDetails(int item_id, string jsonString);
        Task<object> GetInventoryList();
        Task<object> DeleteInventoryItem(int Item_id);
    }
}
