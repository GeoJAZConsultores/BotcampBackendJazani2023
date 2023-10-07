using Jazani.Infrastructure.Cores.Contexts;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.EntityFrameworkCore;
using Jazani.Infrastructure.Cores.Persistences;
using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;

namespace Jazani.Infrastructure.Generals.Persistences
{
    public class MineralTypeRepository : CrudRepository<MineralType, int>, IMineralTypeRepository
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IPaginator<MineralType> _paginator;

        public MineralTypeRepository(ApplicationDbContext dbContext, IPaginator<MineralType> paginator ) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
        }

        public async Task<ResponsePagination<MineralType>> PaginatedSearch(RequestPagination<MineralType> request)
        {
            var filter = request.Filter;

            var query = _dbContext.Set<MineralType>().AsQueryable();

            if(filter is not null)
            {
                query = query
                    .Where(x =>
                        (string.IsNullOrWhiteSpace(filter.Name) || x.Name.ToUpper().Contains(filter.Name.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper()))
                    );
            }


            query = query.OrderByDescending(x => x.Id);


            return await _paginator.Paginate(query, request);
        }
    }
}

