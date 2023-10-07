using AutoMapper;
using Jazani.Domain.Generals.Models;
using Jazani.Core.Paginations;

namespace Jazani.Application.Generals.Dtos.MineralTypes.Profiles
{
	public class MineralTypeProfile : Profile
	{
		public MineralTypeProfile()
		{
			CreateMap<MineralType, MineralTypeDto>();
			//CreateMap<MineralType, MineralTypeDto>().ReverseMap();

            CreateMap<MineralType, MineralTypeSimpleDto>();

			CreateMap<MineralType, MineralTypeSaveDto>().ReverseMap();

			CreateMap<MineralType, MineralTypeFilterDto>().ReverseMap();


			CreateMap<ResponsePagination<MineralType>, ResponsePagination<MineralTypeDto>>();
			CreateMap<RequestPagination<MineralType>, RequestPagination<MineralTypeFilterDto>>()
				.ReverseMap();
		}
	}
}

