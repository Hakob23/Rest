using System.Collections.Generic;
using System.Linq;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantsMenu.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AlcoholDrinksController : Controller
    {
        private ProductsRepository productsRepository;
        public AlcoholDrinksController()
        {
            this.productsRepository = new ProductsRepository();
        }

        // GET
        [HttpGet]
        //[Authorize]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Get()
        {
            var result = this.productsRepository.GetAll<AlcoholDrink>();
            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        // GET api/<controller>/5
        [HttpGet("{restaurantName}")]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Get(string restaurantName)
        {
            var result = this.productsRepository.Get<AlcoholDrink>(restaurantName);

            if (result == null)
            {
                return new StatusCodeResult(404);
            }
            return new JsonResult(result);
        }

        // GET api/<controller>?restaurantName=max&id=4
        [HttpGet("{restaurantName}/{id}")]
        [Authorize(Policy = "Restaurant")]
        public AlcoholDrink Get(string restaurantName, int id)
        {
            return this.productsRepository.Get<AlcoholDrink>(restaurantName).Where(a => a.Id == id).First();
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Post([FromBody]AlcoholDrink value)
        {
            var result = this.productsRepository.CreateProduct(value);
            if (result == false)
            {
                return new StatusCodeResult(202);
            }
            return new JsonResult(result);
        }

        // PUT api/<controller>
        [HttpPut]
        [Authorize(Policy = "Restaurant")]
        public IActionResult Put([FromBody]AlcoholDrink value)
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
        public IActionResult Delete([FromBody]AlcoholDrink value)
        {
            var result = this.productsRepository.DeleteProduct(value);
            if (result == false)
                return new StatusCodeResult(404);

            return new JsonResult(result);
        }
    }
}