using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaturdayReviewTodo.Application.Core.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetEntityById(int id);

        Task<T> CreateEntity(T entity);

        Task DeleteEntity(T entity);

        Task<T> UpdateEntity(T entity);
    }
}
