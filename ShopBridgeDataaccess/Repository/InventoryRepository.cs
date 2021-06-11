using Npgsql;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using ShopBridgeDataaccess.Repository.Interface;
using System;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace ShopBridgeDataaccess.Repository
{
    public class InventoryRepository:IInventoryRepository
    {
        private readonly IConfiguration _configuration;

        public InventoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<object> AddInventoryDetails(string itemjson)
        {
            try
            {
                string logDbConnectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
                using (IDbConnection con = new NpgsqlConnection(logDbConnectionString))
                {

                    con.Open();
                    var querySQL = @"SELECT * FROM public.addproductitem('" + itemjson + "')";
                    var result = con.ExecuteScalar<dynamic>(querySQL);

                    return result;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<object> UpdateInventoryDetails(int item_id, string Itemjson)
        {
            try
            {
                string logDbConnectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
                using (IDbConnection con = new NpgsqlConnection(logDbConnectionString))
                {

                    con.Open();
                    var querySQL = @"SELECT * FROM public.updateproductitem(" + item_id + ",'" + Itemjson + "')";
                    var result = con.ExecuteScalar<dynamic>(querySQL);

                    return result;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<object> GetItemList()
        {
            try
            {
                string logDbConnectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
                using (IDbConnection con = new NpgsqlConnection(logDbConnectionString))
                {
                    con.Open();
                    var responseQuery = @"SELECT * FROM public.GetProductlist()";
                    var responseResult = con.ExecuteScalar<dynamic>(responseQuery);
                    return responseResult;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region delete item
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<object> DeleteInventoryItem(int Item_id)
        {
            try
            {
                string logDbConnectionString = _configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
                using (IDbConnection con = new NpgsqlConnection(logDbConnectionString))
                {
                    con.Open();
                    var querySQL = @"SELECT public.Deleteproductitem(" + Item_id + ")";
                    var result = con.ExecuteScalar<dynamic>(querySQL);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
