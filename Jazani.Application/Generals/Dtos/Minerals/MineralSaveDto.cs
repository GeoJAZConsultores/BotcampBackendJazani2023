using System;
namespace Jazani.Application.Generals.Dtos.Minerals
{
	public class MineralSaveDto
	{
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Symbol { get; set; }
        public int MineraltypeId { get; set; }
    }
}

