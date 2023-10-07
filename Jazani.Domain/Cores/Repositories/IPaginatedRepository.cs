using Jazani.Core.Paginations;


namespace Jazani.Domain.Cores.Repositories
{
	public interface IPaginatedRepository<T>
	{
		Task<ResponsePagination<T>> PaginatedSearch(RequestPagination<T> request);
	}
}

