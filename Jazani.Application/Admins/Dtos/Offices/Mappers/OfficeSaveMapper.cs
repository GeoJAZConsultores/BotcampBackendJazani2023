using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Offices.Mappers
{
	public class OfficeSaveMapper : Profile
	{
		public OfficeSaveMapper()
		{
			CreateMap<Office, OfficeSaveDto>().ReverseMap();
		}
	}
}

