using Jazani.Core.Paginations;
namespace Jazani.Domain.Cores.Paginations
{
	public interface IPaginator<T>
	{
		Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request);
	}
}

