using System;
namespace Jazani.Application.Generals.Dtos.PersonTypes
{
	public class PersonTypeSaveDto
	{
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}

