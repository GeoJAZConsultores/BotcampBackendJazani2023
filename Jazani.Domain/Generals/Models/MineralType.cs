using System;
namespace Jazani.Domain.Generals.Models
{
	public class MineralType
	{
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}

