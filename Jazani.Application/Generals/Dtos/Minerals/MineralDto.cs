using System;
using Jazani.Application.Generals.Dtos.MineralTypes;

namespace Jazani.Application.Generals.Dtos.Minerals
{
	public class MineralDto
	{
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Symbol { get; set; }
        public MineralTypeSimpleDto Mineraltype { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
    }
}

