using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantsAddAndOrder.Models;

namespace RestaurantsAddAndOrder.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurants")]
    public class RestaurantsController : Controller
    {
        SpExecuter spExecuter;

        public RestaurantsController()
        {
            var cnnStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"MAXIM-PC\SQLSERVER",
                InitialCatalog = "RestaurantsTables",
                IntegratedSecurity = true
            };

            this.spExecuter = new SpExecuter(cnnStringBuilder.ConnectionString);
        }

        [HttpPost]
        public void Post([FromBody]Restaurant rest)
        {
            // adding user to database using spExecuter library
            this.spExecuter.ExecuteSpNonQuery(
                 "AddTable",
                 new[]
                 {
                    new KeyValuePair<string,object>("restaurant",rest.RestaurantName),
                    new KeyValuePair<string, object>("tableid",rest.TableID)
                 });
        }

        [HttpDelete]
        public void Delete([FromBody]Restaurant rest)
        {
            this.spExecuter.ExecuteSpNonQuery(
                "DeleteTable",
                new[]
                {
                    new KeyValuePair<string,object>("restaurant",rest.RestaurantName),
                    new KeyValuePair<string, object>("Id",rest.TableID)
                });
        }

        [HttpGet]
        public int Get(string restaurantName)
        {
            return this.spExecuter.ExecuteEntitySp<int>(
               "GetTables",
               new[]
                {
                    new KeyValuePair<string,object>("restaurant",restaurantName)
                });
        }
    }
}