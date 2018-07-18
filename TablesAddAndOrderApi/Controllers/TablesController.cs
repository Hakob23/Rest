using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TablesAddAndOrderApi.Controllers
{
    [Produces("application/json")]
    [Route("api/tables")]
    public class TablesController : Controller
    {
        SpExecuter spExecuter;

        public TablesController()
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
        public void Post([FromBody]table table)
        {
            this.spExecuter.ExecuteSpNonQuery(
                "AddTable",
                new[]
                {
                    new KeyValuePair<string, object>("restaurant", table.restaurant),
                    new KeyValuePair<string, object>("tableid", table.tableID)
                });
        }
    }
}