using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ShopBridgeInvendory.Services.Interface;
using CommonHelpers.Response;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace ClientAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IInventoryservice _inventory;

      //  static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(InventoryController));

        public InventoryController(IInventoryservice inventory)
        {
            _inventory =inventory;
        }

        #region Additem
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddInventory")]
        public async Task<object> AddInventoryDetails()
        {
            var responseObj = new JObject();
            var jArray = new JArray() { };
            try
            {
                //if(client_id == 0)
                //{
                //    responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.BAD_REQUEST_MESSAGE);
                //    responseObj.Add("data", jArray);
                //    return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
                //}
                string jsonString;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    jsonString = await reader.ReadToEndAsync();
                }
                var itemId = await _inventory.AddInventoryDetails(jsonString);
                if (itemId != null && itemId.ToString() != "")
                {
                    //Need to move the below customized message
                    var obj = new
                    {
                        error = false,
                        message = "Item inserted",
                        data = new { id = Convert.ToInt32(itemId) }
                    };
                    return obj;
                }
                else
                {
                    responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.NOT_FOUND_MESSAGE);
                    responseObj.Add("data", jArray);
                    return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
                }

            }
            catch (Exception ex)
            {
               // _log4net.Debug(ex);
                responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.ERROR_MESSAGE);
                responseObj.Add("data", jArray);
                return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
            }
        }
        #endregion
        #region update item
        /// <summary>
        /// update item
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateInventory")]
        public async Task<object> UpdateInventoryDetails(int item_id)
        {
            var responseObj = new JObject();
            var jArray = new JArray() { };
            try
            {
                if (item_id == 0)
                {
                    responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.BAD_REQUEST_MESSAGE);
                    responseObj.Add("data", jArray);
                    return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
                }
                string jsonString;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    jsonString = await reader.ReadToEndAsync();
                }
                var itemid = await _inventory.UpdateInventoryDetails(item_id, jsonString);
                if (itemid != null && itemid.ToString() != "")
                {
                    var obj = new
                    {
                        error = false,
                        message = "Item updated",
                        data = new { id = Convert.ToInt32(itemid) }
                    };
                    return obj;
                }
                else
                {
                    responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.NOT_FOUND_MESSAGE);
                    responseObj.Add("data", jArray);
                    return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
                }

            }
            catch (Exception ex)
            {
               // _log4net.Debug(ex);
                responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.ERROR_MESSAGE);
                responseObj.Add("data", jArray);
                return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
            }
        }
        #endregion

        #region InventoryList
        /// <summary>
        /// Get InventoryList List
        /// </summary>       
        /// <returns></returns>
        [HttpGet]
        [Route("GetInventoryList")]
        public async Task<object> GetInventoryList()
        {
            var responseObj = new JObject();
            var jArray = new JArray() { };
            try
            {
                
                var itemList = await _inventory.GetInventoryList();
                if (itemList != null && itemList != "")
                {
                    var result = JsonConvert.DeserializeObject<object>(itemList.ToString());
                    return System.Text.Json.JsonSerializer.Deserialize<object>(result.ToString());
                }
                else
                {
                    responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.NOT_FOUND_MESSAGE);
                    responseObj.Add("items", jArray);
                    return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
                }
            }
            catch (Exception ex)
            {
               // _log4net.Debug(ex);
                responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.ERROR_MESSAGE);
                responseObj.Add("items", jArray);
                return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
            }
        }
        #endregion

        #region Delete Item
        /// <summary>
        /// Delete item
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<object> DeleteInventoryItem(int item_id)
        {
            var responseObj = new JObject();
            var jArray = new JArray() { };
            try
            {

                if (item_id == 0)
                {
                    responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.BAD_REQUEST_MESSAGE);
                    responseObj.Add("data", jArray);
                    return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
                }
                var itemid = await _inventory.DeleteInventoryItem(item_id);
                if (itemid != null && itemid.ToString() != "" && itemid.ToString() != "0")
                {
                    var obj = new
                    {
                        error = false,
                        message = "Item Deleted",
                        data = new { id = Convert.ToInt32(itemid) }
                    };
                    return obj;
                }
                else
                {
                    responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.NOT_FOUND_MESSAGE);
                    responseObj.Add("data", jArray);
                    return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
                }

            }
            catch (Exception ex)
            {

               // _log4net.Debug(ex);
                responseObj = JObject.FromObject(ResponseInfo.ResponseStatusMessage.ERROR_MESSAGE);
                responseObj.Add("data", jArray);
                return System.Text.Json.JsonSerializer.Deserialize<object>(responseObj.ToString());
            }

        }
        #endregion
    }
}