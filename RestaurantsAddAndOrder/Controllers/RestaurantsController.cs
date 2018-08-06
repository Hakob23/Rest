using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;
using RestaurantsAddAndOrder.Models;

namespace RestaurantsAddAndOrder.Controllers
{
    [Produces("application/json")]
    [Route("api/restaurants")]
    public class RestaurantsController : Controller
    {
        readonly SpExecuter spExecuter;

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

        [HttpPost("{restaurantName}")]
        public void Post(string restaurantName)
        {
            // adding user to database using spExecuter library
            this.spExecuter.ExecuteSpNonQuery(
                 "AddTable",
                 new[]
                 {
                    new KeyValuePair<string, object>("restaurant", restaurantName)
                 });

        }


        [HttpPost("{tableId}")]
        public void Post([FromBody]Restaurant table)
        {
            // adding user to database using spExecuter library
            this.spExecuter.ExecuteSpNonQuery(
                 "AddTableWithId",
                 new[]
                 {
                    new KeyValuePair<string, object>("Id", 0),
                    new KeyValuePair<string, object>("RestaurantName", table.RestaurantName)
                 });

        }

        [HttpDelete]
        public void Delete([FromBody]Restaurant rest)
        {
            this.spExecuter.ExecuteSpNonQuery(
                "DeleteTable",
                new[]
                {
                    new KeyValuePair<string, object>("Id", rest.Id)
                });
        }

        [HttpGet("{restaurantName}/{Id}")]
        public IActionResult Get(string restaurantName, int Id)
        {
            var result = this.spExecuter.ExecuteSp<Restaurant>(
               "GetTables",
               new[]
                {
                    new KeyValuePair<string, object>("restaurant", restaurantName)
                });
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        [HttpGet("{tableId}")]
        public IActionResult Get(string tableId)
        {
            var result = this.spExecuter.ExecuteEntitySp<Restaurant>(
               "GetRestaurantbyTableId",
               new[]
                {
                    new KeyValuePair<string, object>("tableId", tableId)
                });

            if (result == null)
            {
                return new StatusCodeResult(404);
            }

            return new JsonResult(result);
        }
    }
}