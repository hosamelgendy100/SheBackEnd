using She.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace She.Data.Interfaces
{
    public interface ISubCategory
    {
        Task<SubCategory> GetById(int id);
        Task<List<SubCategory>> List();
        Task Add(SubCategory category);
        Task<bool> Update(SubCategory category);
        Task Delete(int id);
        Task<bool> SaveAll();
        IEnumerable<SubCategory> GetSubcategoriesByCategoryId(int categoryId);
    }
}
