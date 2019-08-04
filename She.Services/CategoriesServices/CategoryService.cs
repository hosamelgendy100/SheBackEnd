using Microsoft.EntityFrameworkCore;
using She.Data;
using She.Data.Interfaces;
using She.Data.Models;
using She.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace She.Services.CategoriesServices
{
    public class CategoryService : ICategory
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Category category)
        {
            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id) { _context.Remove(await _context.Categories.FindAsync(id));  }

        public async Task<Category> GetById(int id) => await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);

        public async Task<List<Category>> List() => await _context.Categories.ToListAsync();

        public async Task<bool> SaveAll() => await _context.SaveChangesAsync() > 0;

        public async Task<bool> Update(Category category )
        {
            _context.Entry(category).State = EntityState.Modified;
            if (await SaveAll()) return true;
            else return false;
        }



        ///---
    }


}
