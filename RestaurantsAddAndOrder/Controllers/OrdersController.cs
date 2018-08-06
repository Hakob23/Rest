using System.Collections.Generic;
using System.Data.SqlClient;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;
using RestaurantsAddAndOrder.Models;

namespace RestaurantsAddAndOrder.Controllers
{
    [Produces("application/json")]
    [Route("api/orders")]
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

        [HttpGet("{tableId}")]
        public IActionResult Get(int tableId)
        {
            var result = this.spExecuter.ExecuteSp<Orders>(
            "GetOrderTableId",
            new[]
            {
                    new KeyValuePair<string,object>("TableId", tableId),
            });
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Orders order)
        {
            // adding user to database using spExecuter library
            var result = this.spExecuter.ExecuteSpNonQuery(
                 "CreateOrder",
                 new[]
                 {
                    new KeyValuePair<string,object>("TableId",order.TableID),
                    new KeyValuePair<string, object>("Restaurant",order.Restaurant),
                    new KeyValuePair<string, object>("OrderCategory",order.OrderCategory),
                    new KeyValuePair<string, object>("MealId",order.MealID),
                    new KeyValuePair<string, object>("Quantity",order.Quantity),
                    new KeyValuePair<string, object>("Messege",order.Messege),
                    new KeyValuePair<string, object>("Address", order.Address),
                    new KeyValuePair<string, object>("Price", order.Price)
                 });
            if (result == 0)
            {
                return new StatusCodeResult(404);
            }
            return new StatusCodeResult(200);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.spExecuter.ExecuteSpNonQuery(
                "DeleteOrder",
                new[]
                {
                    new KeyValuePair<string, object>("Id",id)
                });
        }

        [HttpPut("{id}/{quantity}")]
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