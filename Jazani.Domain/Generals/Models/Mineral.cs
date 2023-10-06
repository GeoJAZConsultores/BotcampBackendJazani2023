namespace Jazani.Domain.Generals.Models
{
    public class Mineral
	{
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? Symbol { get; set; }
        public int MineraltypeId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }

        public virtual MineralType MineralType { get; set; }
    }
}

