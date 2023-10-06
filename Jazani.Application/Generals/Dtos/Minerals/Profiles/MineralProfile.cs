using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Minerals.Profiles
{
	public class MineralProfile : Profile
	{
		public MineralProfile()
		{
			CreateMap<Mineral, MineralDto>();


			CreateMap<Mineral, MineralSaveDto>().ReverseMap();
		}
	}
}

