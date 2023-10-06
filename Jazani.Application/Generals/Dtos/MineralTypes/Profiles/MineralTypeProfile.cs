using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Profiles
{
	public class MineralTypeProfile : Profile
	{
		public MineralTypeProfile()
		{
			CreateMap<MineralType, MineralTypeDto>();
			CreateMap<MineralType, MineralTypeSimpleDto>();

			CreateMap<MineralType, MineralTypeSaveDto>().ReverseMap();
		}
	}
}

