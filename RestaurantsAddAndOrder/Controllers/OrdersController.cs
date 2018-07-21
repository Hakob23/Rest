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
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        SpExecuter spExecuter;

        public OrdersController()
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
        public void Post([FromBody]Orders order)
        {
            // adding user to database using spExecuter library
            this.spExecuter.ExecuteSpNonQuery(
                 "CreateOrder",
                 new[]
                 {
                    new KeyValuePair<string,object>("TableId",order.TableID),
                    new KeyValuePair<string, object>("Restaurant",order.RestaurantName),
                    new KeyValuePair<string, object>("OrderCategory",order.OrderCategory),
                    new KeyValuePair<string, object>("MealId",order.MealID),
                    new KeyValuePair<string, object>("Quantity",order.Quantity),
                    new KeyValuePair<string, object>("Messege",order.Messege)
                 });
        }

        [HttpDelete]
        public void Delete(int id)
        {
            this.spExecuter.ExecuteSpNonQuery(
                "DeleteOrder",
                new[]
                {
                    new KeyValuePair<string, object>("Id",id)
                });
        }

        [HttpPut]
        public void Put(int id, int quantity)
        {
            this.spExecuter.ExecuteSpNonQuery(
                "UpdateOrderQuantity",
                new[]
                {
                    new KeyValuePair<string, object>("Quantity",quantity),
                    new KeyValuePair<string, object>("Id",id)
                });
        }

    }
}