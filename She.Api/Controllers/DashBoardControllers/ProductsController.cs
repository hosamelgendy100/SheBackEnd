using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using She.Data;
using She.Data.Dtos.ProductDtos;
using She.Data.Interfaces;
using She.Data.Models;

namespace She.Api.DashBoardControllers.Controllers
{
    [Route("api/[controller]")] [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct _productRepo;
        private readonly IMapper _mapper;

        public ProductsController( IProduct productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productRepo.List();
            var productsListToReturn = _mapper.Map<IEnumerable<ProductToDisplayDto>>(products);
            return Ok(productsListToReturn);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepo.GetById(id);
            if (product == null) return NotFound();
            var productToReturn = _mapper.Map<ProductDetailsDto>(product);
            return Ok(productToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            var productUpdated = await _productRepo.Update(product);
            if (productUpdated) return Ok("Updated");
            else return BadRequest("Product has not updated");
        }


        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _productRepo.Add(product);
            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }


        [HttpPost("AddProductPhotos/{productId}")]
        public async Task<IActionResult> SaveImages(int productId)
        {
            if(productId == 0) return BadRequest("Product Id can't be Zero");

            var files = HttpContext.Request.Form.Files;
            var imagesSaved = await _productRepo.SaveImages(productId, files);
            if (imagesSaved) return Ok("Saved");
            else return BadRequest("Image was not saved");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            await _productRepo.Delete(id);
            return Ok("Product Deleted");
        }

      
    }
}
