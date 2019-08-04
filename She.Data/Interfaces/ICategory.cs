using She.Data.Models;
using She.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace She.Data.Interfaces
{
    public interface ICategory
    {
        Task<Category> GetById(int id);
        Task<List<Category>> List();
        Task Add(Category category);
        Task<bool> Update(Category category);
        Task Delete(int id);
        Task<bool> SaveAll();
    }
}
