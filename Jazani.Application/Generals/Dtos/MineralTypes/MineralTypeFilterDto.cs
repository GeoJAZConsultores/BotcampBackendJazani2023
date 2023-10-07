namespace Jazani.Application.Generals.Dtos.MineralTypes
{
    public class MineralTypeFilterDto
	{
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public bool State { get; set; }
    }
}

