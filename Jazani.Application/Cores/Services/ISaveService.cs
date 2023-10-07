using System;
namespace Jazani.Application.Cores.Services
{
	public interface ISaveService<TDto, TDtoSave, ID>
    {
        Task<TDto> CreateAsync(TDtoSave saveDto);
        Task<TDto> EditAsync(ID id, TDtoSave saveDto);
    }
}

