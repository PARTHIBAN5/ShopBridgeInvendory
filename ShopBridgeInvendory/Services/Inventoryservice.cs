using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ShopBridgeInvendory.Services.Interface;

namespace ShopBridgeInvendory.Services
{
    public class Inventoryservice:IInventoryservice
    {
        private readonly string BaseUrl = string.Empty;
        private readonly IConfiguration _configuration;

        public Inventoryservice(IConfiguration configuration)
        {
            _configuration = configuration;
            BaseUrl = _configuration.GetSection("DataAccessUrl").Value;
        }
        #region Add Order
        public async Task<object> AddInventoryDetails(string jsonString)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = client.PostAsync(BaseUrl + "api/Inventory/AddInventoryDetails?", content).Result;
                    if (Res.IsSuccessStatusCode)
                    {
                        return Res.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return null;
                    }


                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
        #region update item
        public async Task<object> UpdateInventoryDetails(int item_id, string jsonitem)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(jsonitem.ToString(), Encoding.UTF8, "application/json");
                    HttpResponseMessage Res = client.PostAsync(BaseUrl + "api/Inventory/UpdateInventoryDetails?item_id=" + item_id, content).Result;
                    if (Res.IsSuccessStatusCode)
                    {
                        return Res.Content.ReadAsStringAsync().Result;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion
        public async Task<object> GetInventoryList()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = client.GetAsync("api/Inventory/GetItemList").Result;
                    if (Res.IsSuccessStatusCode)
                    {
                        return Res.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch
            {
                throw;
            }
            return null;
        }
        public async Task<object> DeleteInventoryItem(int item_id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = client.GetAsync("api/Inventory/deleteitem?item_id=" + item_id).Result;
                    if (Res.IsSuccessStatusCode)
                    {
                        return Res.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            catch
            {
                throw;
            }
            return null;
        }
    }
}
