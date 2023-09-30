using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Offices.Mappers
{
	public class OfficeMapper : Profile
	{
		public OfficeMapper()
		{
			CreateMap<Office, OfficeDto>();
		}
	}
}

