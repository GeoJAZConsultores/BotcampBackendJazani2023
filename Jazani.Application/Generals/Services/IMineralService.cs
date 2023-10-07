using System;
using Jazani.Application.Cores.Services;
using Jazani.Application.Generals.Dtos.Minerals;

namespace Jazani.Application.Generals.Services
{
	public interface IMineralService : ICrudService<MineralDto, MineralSaveDto, int>
    {
    }
}

