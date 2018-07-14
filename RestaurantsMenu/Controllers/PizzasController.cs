using System.Collections.Generic;
using System.Linq;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantsMenu.Controllers
{
    [Route("api/pizzas")]
    [Produces("application/json")]
    public class PizzasController : Controller
    {
        private ProductsRepository productsRepository;
        public PizzasController()
        {
            this.productsRepository = new ProductsRepository();
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return this.productsRepository.GetAll<Pizza>();
        }

        // GET api/<controller>/5
        [HttpGet]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Get(string restaurantName)
        {
            var result = this.productsRepository.Get<Pizza>(restaurantName);
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        // GET api/<controller>?restaurantName=max&id=4
        [HttpGet]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Get(string restaurantName, int id)
        {
            var result = this.productsRepository.Get<Pizza>(restaurantName).Where(a => a.Id == id).First();
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Post([FromBody]Pizza value)
        {
            var result = this.productsRepository.CreateProduct(value);
            if (result == false)
            {
                return new StatusCodeResult(202);
            }
            return new JsonResult(result);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Put([FromBody]Pizza value)
        {
            var result = this.productsRepository.UpdateProduct(value);
            if (result == false)
            {
                return new StatusCodeResult(202);
            }
            return new JsonResult(result);
        }
        
        // DELETE api/<controller>/5
        [HttpDelete]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Delete([FromBody]Pizza product)
        {
            var result = this.productsRepository.DeleteProduct(product);
            if (result == false)
            {
                return new StatusCodeResult(202);
            }
            return new JsonResult(result);
        }
    }
}