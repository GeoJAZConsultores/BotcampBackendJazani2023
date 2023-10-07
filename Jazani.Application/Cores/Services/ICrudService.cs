using System;
namespace Jazani.Application.Cores.Services
{
	public interface ICrudService<TDto, TDtoSave, ID> :
		IQueryService<TDto,ID>,
		ISaveService<TDto,TDtoSave, ID>,
		IDisableService<TDto,ID>
	{
    }
}

