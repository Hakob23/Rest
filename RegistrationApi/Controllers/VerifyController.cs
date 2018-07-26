using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationApi.Controllers
{
    //[Produces("application/json")]
    [Route("api/verify")]
    public class VerifyController : Controller
    {
        SpExecuter spExecuter;

        public VerifyController()
        {
            var cnnStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"ARTHUR-PC\SQLEXPRESS",
                InitialCatalog = "UsersDB",
                IntegratedSecurity = true
            };

            this.spExecuter = new SpExecuter(cnnStringBuilder.ConnectionString);
        }

        /// <summary>
        /// account verification
        /// </summary>
        /// <param name="id">verification code</param>
        [HttpGet("{id}")]
        public void Get(string id)
        {
            this.spExecuter.ExecuteSpNonQuery(
                 "uspUpdateIsActivated",
                 new[]
                 {
                    new KeyValuePair<string,object>("Id", new Guid(id)),
                 });
        }
    }
}