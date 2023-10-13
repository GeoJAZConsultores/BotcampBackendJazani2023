using System;
namespace Jazani.Application.Admins.Dtos.Users
{
	public class UserSaveDto
	{
        public string Name { get; set; } = default!;
        public string? LastName { get; set; }
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public int RoleId { get; set; }
    }
}

