using Microsoft.EntityFrameworkCore;
using SaturdayReviewTodo.Application.Core.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Domain.Infrastructure.Persistence.Repo
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly TodoDbContext _context;

        public BaseRepository(TodoDbContext context)
        {
            _context = context;
            
        }

        public async Task<T> CreateEntity(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteEntity(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
