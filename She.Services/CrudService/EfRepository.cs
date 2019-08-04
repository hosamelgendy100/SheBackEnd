using AutoMapper;
using Microsoft.EntityFrameworkCore;
using She.Data;
using She.Data.Interfaces;
using She.Data.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace She.Services.CrudService
{
    public class EfRepository : IRepository
    {
        private readonly DataContext _context;

        public EfRepository(DataContext context) { _context = context; }

        public async Task<T> Add<T>(T entity) where T : BaseEntity
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async void Delete<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> GetById<T>(int id) where T : BaseEntity => await _context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);

        public async Task<List<T>> List<T>() where T : BaseEntity => await _context.Set<T>().ToListAsync();

        public async void Update<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
