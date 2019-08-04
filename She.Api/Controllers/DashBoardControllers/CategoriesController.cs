using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using She.Data;
using She.Data.Dtos;
using She.Data.Interfaces;
using She.Data.Models;

namespace She.Api.DashBoardControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategory _repo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategory repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _repo.List();
            var categoriesToReturn = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoriesToReturn);
        }


        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _repo.GetById(id);
            if (category == null) return NotFound();
            var categoryToReturn = _mapper.Map<CategoryDto>(category);
            return Ok(categoryToReturn);
        }


        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto categoryDto)
        {
            if (id != categoryDto.Id) { return BadRequest(); }
            var category = _mapper.Map<Category>(categoryDto);
            var updated = await _repo.Update(category);
            if (updated) return Ok("Updated");
            else return BadRequest("Could not update");
        }


        // POST: api/Categories
        [HttpPost]
        public async Task<IActionResult> PostCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repo.Add(category);
            var categoryToReturn = _mapper.Map<CategoryDto>(category);
            return CreatedAtAction("GetCategory", new { id = categoryToReturn.Id }, categoryToReturn);
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _repo.GetById(id);
            if (category == null) return NotFound();
            await _repo.Delete(id);
            if (await _repo.SaveAll()) return Ok("Deleted");
            else return BadRequest("Could not be deleted");
        }



    }
}
