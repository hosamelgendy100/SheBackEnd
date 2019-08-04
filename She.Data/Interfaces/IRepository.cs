using She.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace She.Data.Interfaces
{
    public interface IRepository
    {
        Task<T> GetById<T>(int id) where T : BaseEntity;
        Task<List<T>> List<T>() where T : BaseEntity;
        Task<T> Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
    }
}
