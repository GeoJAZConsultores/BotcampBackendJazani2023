using Jazani.Application.Admins.Dtos.Offices;

namespace Jazani.Application.Admins.Services
{
	public interface IOfficeService
	{
		Task<IReadOnlyList<OfficeDto>> FindAllAsync();
		Task<OfficeDto?> FindByIdAsync(int id);
	}
}

