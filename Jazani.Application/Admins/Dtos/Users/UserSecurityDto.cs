using System;
using Jazani.Core.Securities.Etities;

namespace Jazani.Application.Admins.Dtos.Users
{
	public class UserSecurityDto : UserDto
	{
		public SecurityEntity Security { get; set; }
	}
}

