using System;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Cores.Services;

namespace Jazani.Application.Admins.Services
{
	public interface IUserService : ISaveService<UserDto, UserSaveDto, int>
    {
	}
}

