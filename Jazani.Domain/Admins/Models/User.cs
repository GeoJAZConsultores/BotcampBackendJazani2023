using Jazani.Domain.Cores.Models;

namespace Jazani.Domain.Admins.Models
{
	public class User : CoreModel<int>
	{
		public string Name { get; set; } = default!;
		public string? LastName { get; set; }
		public string Email { get; set; } = default!;
		public string Password { get; set; } = default!;
		public int RoleId { get; set; }
	}
}

