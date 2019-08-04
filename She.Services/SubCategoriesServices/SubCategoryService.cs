using Microsoft.EntityFrameworkCore;
using She.Data;
using She.Data.Interfaces;
using She.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace She.Services.SubCategoriesServices
{
    public class SubCategoryService : ISubCategory
    {
        private readonly DataContext _context;

        public SubCategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task Add(SubCategory subCategory)
        {
            await _context.AddAsync(subCategory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id) { _context.Remove(await _context.SubCategories.FindAsync(id)); }

        public async Task<SubCategory> GetById(int id) => await _context.SubCategories.Include(s => s.Category).SingleOrDefaultAsync(c => c.Id == id);

        public IEnumerable<SubCategory> GetSubcategoriesByCategoryId(int categoryId)
        {
            return _context.SubCategories.Where(s => s.CategoryId == categoryId).Include(s => s.Category).ToList();
        }

        public async Task<List<SubCategory>> List() => await _context.SubCategories.Include(c => c.Category).ToListAsync();

        public async Task<bool> SaveAll() => await _context.SaveChangesAsync() > 0;

        public async Task<bool> Update(SubCategory subCategory)
        {
            _context.Entry(subCategory).State = EntityState.Modified;
            if (await SaveAll()) return true;
            else return false;
        }



        ///---
    }
}
