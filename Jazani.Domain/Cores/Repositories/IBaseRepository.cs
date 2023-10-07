using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Cores.Repositories
{
    public interface IBaseRepository<T, ID> where T : CoreModel<ID>
	{
        Task<IReadOnlyList<T>> FindAllAsync();
        Task<T?> FindByIdAsync(ID id);
        Task<T> SaveAsync(T entity);
        Task<T?> DisabledByIdAsync(ID id);
    }
}

