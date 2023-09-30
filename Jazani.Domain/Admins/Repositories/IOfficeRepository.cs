using System;
using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
	public interface IOfficeRepository
	{
		Task<IReadOnlyList<Office>> FindAllAsync();
		Task<Office?> FindByIdAsync(int id);
		Task<Office> SaveAsync(Office office);
	}
}

