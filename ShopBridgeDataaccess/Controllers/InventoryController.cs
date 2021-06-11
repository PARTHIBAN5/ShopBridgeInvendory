using ShopBridgeDataaccess.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppDataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryRepository _inventory;

        public InventoryController(IInventoryRepository inventory)
        {
            _inventory = inventory;
        }
    
        #region Add to do
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddInventoryDetails")]
        public async Task<object> AddInventoryDetails()
        {
            try
            {
                string jsonString;
                StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
                jsonString = await reader.ReadToEndAsync();
                return await _inventory.AddInventoryDetails(jsonString);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion
        #region Add todo details
        /// <summary>
        /// update todo details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateInventoryDetails")]
        public async Task<object> UpdateInventoryDetails(int item_id)
        {
            try
            {
                string jsonString;
                StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
                jsonString = await reader.ReadToEndAsync();
                return await _inventory.UpdateInventoryDetails(item_id, jsonString);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion

        #region get itemlist
        /// <summary>
        /// Get Item List
        /// </summary>      
        /// <returns></returns>
        [HttpGet]
        [Route("GetItemList")]
        public async Task<object> GetItemList()
        {
            try
            {
                return await _inventory.GetItemList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region delete todo
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("deleteitem")]
        public async Task<object> DeleteInventoryItem(int Item_id)
        {
            try
            {
                return await _inventory.DeleteInventoryItem(Item_id);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
