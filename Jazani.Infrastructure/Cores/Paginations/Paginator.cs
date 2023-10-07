using Jazani.Domain.Cores.Paginations;
using Jazani.Core.Paginations;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infrastructure.Cores.Paginations
{
    public class Paginator<T> : IPaginator<T>
    {
        public async Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request)
        {
            var total = await query.CountAsync();
            var pagination = new Pagination(total, request.Page, request.PerPage);

            var sizePerPage = pagination.PerPage;

            var diference = (pagination.To - pagination.From) + 1;

            if (diference < pagination.PerPage) sizePerPage = diference;

            var currentPage = pagination.CurrentPage;
            if (currentPage > 0) currentPage = pagination.CurrentPage - 1;


            var queryPagination = query.Skip(currentPage * sizePerPage).Take(sizePerPage);
            var data = await queryPagination.ToListAsync();


            return new ResponsePagination<T>(pagination)
            {
                Data = data
            };
        }
    }
}

