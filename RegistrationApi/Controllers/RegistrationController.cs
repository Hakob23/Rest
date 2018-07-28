using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Models;
using DatabaseAccess;
using System.Net.Mail;
using System.Net;

namespace RegistrationApi.Controllers
{
    [Produces("application/json")]
    [Route("api/registration")]
    public class RegistrationController : Controller
    {
        // constructing stored procedure executer
        SpExecuter spExecuter;

        /// <summary>
        /// Registration Controller constructor
        /// </summary>
        public RegistrationController()
        {
            var cnnStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"MAXIM-PC\SQLSERVER",
                InitialCatalog = "UsersDB",
                IntegratedSecurity = true
            };

            this.spExecuter = new SpExecuter(cnnStringBuilder.ConnectionString);

        }

        /// <summary>
        /// Get All Restaurants
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var result = this.spExecuter.ExecuteSp<RestName>(
                "uspGetAllRestaurants");

            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }


        [HttpGet("{username}")]
        public IActionResult Get(string username)
        {
            var result = this.spExecuter.ExecuteScalarSp<string>(
                "uspGetRoleByUsername",
                new[]
                {
                    new KeyValuePair<string, object>("UserName", username)
                });

            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        // POST api/registration
        [HttpPost]
        public IActionResult Post([FromBody]user user)
        {
            // generating activation code
            user.ActivationCode = Guid.NewGuid();
            
            // Hashing password
            user.Password = Crypto.Crypto.Hash(user.Password);

            // adding user to database using spExecuter library
            var result = this.spExecuter.ExecuteSpNonQuery(
                 "uspCreateUser",
                 new[]
                 {
                    new KeyValuePair<string,object>("UserName",user.UserName),
                    new KeyValuePair<string, object>("Email",user.Email),
                    new KeyValuePair<string,object>("Password",user.Password),
                    new KeyValuePair<string,object>("Phone",user.Phone),
                    new KeyValuePair<string, object>("IsEmailVerifyed",user.IsEmailVerifyed),
                    new KeyValuePair<string, object>("ActivationCode",user.ActivationCode),
                    new KeyValuePair<string, object>("Role",user.Role)
                 });

            if (result == -1)
            {
                return new StatusCodeResult(404);
            }
            // send verification link to email
            SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
            return new StatusCodeResult(200);
        }
        
        // PUT api/registration/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/registration/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        /// <summary>
        /// Verification mail sender
        /// </summary>
        /// <param name="Email">email address</param>
        /// <param name="ActivationCode">activation code</param>
        public void SendVerificationLinkEmail(string Email, string ActivationCode)
        {
            // creating verification url
            var verifyUrl = "/api/verify/" + ActivationCode;
            
            // creating verification link
            var link = Request.Scheme + "://" + Request.Host.ToString() + verifyUrl;

            // email sender mail address
            var fromEmail = new MailAddress("maxim.karapetyan@gmail.com");
            
            // to email address
            var toEmail = new MailAddress(Email);
            var fromEmailPassword = "rasputin1#";
           
            // messege subject
            string subject = "Your account is successfully created";

            // messege body
            string body = "<br/><br/>We are excited to tell you that your retaurant account " +
                "is successfully created. Please click on the below link to verify your account <br/><br/>" +
                "<a href = '" + link + "'>" + link + " </a>";

            // smtp client for send messege
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            // creating Mail massege
            using (var messege = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })

            // sending
            smtp.Send(messege);
        }
    }
}