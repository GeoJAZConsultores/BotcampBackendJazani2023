using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Application.Cores.Services;

namespace Jazani.Application.Generals.Services
{
	public interface IMineralTypeService : IPaginatedService<MineralTypeDto, MineralTypeFilterDto>
	{
		Task<IReadOnlyList<MineralTypeDto>> FindAllAsync();
		Task<MineralTypeDto?> FindByIdAsync(int id);
		Task<MineralTypeDto> CreateAsync(MineralTypeSaveDto saveDto);
        Task<MineralTypeDto> EditAsync(int  id, MineralTypeSaveDto saveDto);
		Task<MineralTypeDto> DisabledAsync(int id);
    }
}

