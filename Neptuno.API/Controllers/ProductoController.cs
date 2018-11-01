using Microsoft.AspNetCore.Mvc;
using Neptuno.ServiceLayer.Interfaces;
using System;

namespace Neptuno.API.Controllers
{
    [Route("api/products")]
    public class ProductoController : Controller
    {
        private readonly IProductService productService;
                
        public ProductoController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet()]
        public IActionResult GetProductos()
        {
            //throw new Exception("random error");

            var products = productService.GetProducts();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProdutc(int id)
        {
            var product = productService.GetProduct(id);

            if(product == null)
            {
                return NotFound();
            }

            return new JsonResult(product);
        }
    }
}
