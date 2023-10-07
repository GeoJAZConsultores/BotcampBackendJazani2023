using System;
namespace Jazani.Application.Cores.Services
{
	public interface IDisableService<TDto, ID>
	{
        Task<TDto> DisabledAsync(ID id);
    }
}

