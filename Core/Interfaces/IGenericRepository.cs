using Core.Entities;
using Core.Spicifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetEntityWithSpec(ISpicification<T> spec);

        Task<IReadOnlyList<T>> ListAsync(ISpicification<T> spec);
    }
}
