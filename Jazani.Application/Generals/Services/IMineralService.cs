using System;
using Jazani.Application.Generals.Dtos.Minerals;

namespace Jazani.Application.Generals.Services
{
	public interface IMineralService
	{
		Task<IReadOnlyList<MineralDto>> FindAllAsync();
		Task<MineralDto?> FindByIdAsync(int id);
		Task<MineralDto> CreateAsync(MineralSaveDto saveDto);
        Task<MineralDto> EditAsync(int  id, MineralSaveDto saveDto);
		Task<MineralDto> DisabledAsync(int id);
    }
}

