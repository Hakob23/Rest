using System.Collections.Generic;
using System.Linq;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantsMenu.Controllers
{
    [Route("api/drinks")]
    [Produces("application/json")]
    public class DrinksController : Controller
    {
        private ProductsRepository productsRepository;
        public DrinksController()
        {
            this.productsRepository = new ProductsRepository();
        }

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<Drink> Get()
        {
            return this.productsRepository.GetAll<Drink>();
        }

        // GET api/<controller>/5
        [HttpGet("{restaurantName}")]
        public IActionResult Get(string restaurantName)
        {
            var result = this.productsRepository.Get<Drink>(restaurantName);
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        // GET api/<controller>?restaurantName=max&id=4
        [HttpGet("{restaurantName}/{id}")]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Get(string restaurantName, int id)
        {
            var result = this.productsRepository.Get<Drink>(restaurantName).Where(a => a.Id == id).First();
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Post([FromBody]Drink value)
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
        public IActionResult Put([FromBody]Drink value)
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
        public IActionResult Delete([FromBody]Drink product)
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