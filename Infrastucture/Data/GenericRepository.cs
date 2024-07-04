using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Spicifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastucture.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            this._context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() 
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
           return await _context.Set<T>().FindAsync(id);  
        }

        public async Task<T> GetEntityWithSpec(ISpicification<T> spec)
        {
            return await ApplySpicification(spec).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpicification<T> spec)
        {
            return await ApplySpicification(spec).ToListAsync();
        }


        private IQueryable<T> ApplySpicification(ISpicification<T> spec)
        {
            return SpicificationEvaluater<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
