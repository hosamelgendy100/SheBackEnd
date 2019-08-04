using She.Data.Models;
using She.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace She.Data.Interfaces
{
    public interface IProduct
    {
        Task<Product> GetById(int id);
        Task<List<Product>> List();
        Task Add(Product product);
        Task<bool> Update(Product product);
        Task Delete(int id);
        Task<bool> SaveAll();
        Task<bool> SaveImages(int id, IEnumerable<dynamic> files);
        Task SaveProductSizes(int id, IEnumerable<int> sizes);
    }
}
