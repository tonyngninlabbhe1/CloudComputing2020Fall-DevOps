using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAllProducts()
        {
            Console.WriteLine("Getting all products");

            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProduct(int productId)
        {
            var product = _productService.GetProductById(productId);

            if (product != null) {
                return Ok(product);
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            _productService.AddProduct(product);

            // return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);

            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
        }

        [HttpPut("{productId}")]
        public ActionResult UpdateProduct(int productId, Product productUpdate)
        {
            productUpdate.ProductId = productId;
            _productService.UpdateProduct(productUpdate);

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);

            return Ok();
        }
    }
}