using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using BLL.Interfaces;
using BLL.ModelsDTO.DTO;
using BLL.ModelsDTO.Resources;
namespace Lab6.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController:ControllerBase
    {
        private IProductService productService;
        public ProductsController(IProductService productService)
        {
            
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            return  await productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO> GetProductById(int id)
        {
            return await productService.GetProductById(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductResource productResource)
        {
            await productService.AddProduct(productResource);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {

            return NoContent();
        }
    }
}
