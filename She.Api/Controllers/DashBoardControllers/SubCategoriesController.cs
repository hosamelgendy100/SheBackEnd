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
    public class SubCategoriesController : ControllerBase
    {
        private readonly ISubCategory _repo;
        private readonly IMapper _mapper;

        public SubCategoriesController(ISubCategory repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategories()
        {
            var subCategories = await _repo.List();
            var subCategoriesToReturn = _mapper.Map<IEnumerable<SubCategoryDto>>(subCategories);
            return Ok(subCategoriesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            var subCategory = await _repo.GetById(id);
            if (subCategory == null) return NotFound();
            var SubCategoryToReturn = _mapper.Map<SubCategoryDto>(subCategory);
            return Ok(SubCategoryToReturn);
        }


        [HttpGet("GetSubcategoryByCategoryId/{id}")]
        public IActionResult GetSubcategoryByCategoryId(int id)
        {
            var subcategories = _repo.GetSubcategoriesByCategoryId(id);
            if (subcategories.Count() == 0) return BadRequest("No subcategories with this category id");
            var subcategoriesToReturn = _mapper.Map<IEnumerable<SubCategoryDto>>(subcategories);
            return Ok(subcategoriesToReturn);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubCategory(int id, SubCategoryDto subCategoryDto)
        {
            if (id != subCategoryDto.Id) { return BadRequest(); }
            var subCategory = _mapper.Map<SubCategory>(subCategoryDto);
            var updated = await _repo.Update(subCategory);
            if (updated) return Ok("Updated");
            else return BadRequest("Could not update");
        }

        [HttpPost]
        public async Task<ActionResult> PostSubCategory(SubCategoryDto subCategoryDto)
        {
            var subCategory = _mapper.Map<SubCategory>(subCategoryDto);
            await _repo.Add(subCategory);
            var subCategoryToReturn = _mapper.Map<SubCategoryDto>(subCategory);
            return CreatedAtAction("GetSubCategory", new { id = subCategoryToReturn.Id }, subCategoryToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteSubCategory(int id)
        {
            var subCategory = await _repo.GetById(id);
            if (subCategory == null) return NotFound();
            await _repo.Delete(id);
            if (await _repo.SaveAll()) return Ok("Deleted");
            else return BadRequest("Could not be deleted");
        }



    }
}
