using AutoMapper;
using Jazani.Application.Admins.Dtos.Offices;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class OfficeService : IOfficeService
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public OfficeService(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<OfficeDto>> FindAllAsync()
        {
            IReadOnlyList<Office> offices = await _officeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<OfficeDto>>(offices);
        }

        public async Task<OfficeDto?> FindByIdAsync(int id)
        {
            Office? office = await _officeRepository.FindByIdAsync(id);

            return _mapper.Map<OfficeDto>(office);
        }

        public async Task<OfficeDto> CreateAsync(OfficeSaveDto officeSaveDto)
        {
            Office office = _mapper.Map<Office>(officeSaveDto);
            office.RegistrationDate = DateTime.Now;
            office.State = true;

            Office officeSaved = await _officeRepository.SaveAsync(office);

            return _mapper.Map<OfficeDto>(officeSaved);
        }

        public async Task<OfficeDto> EditAsync(int id, OfficeSaveDto officeSaveDto)
        {

            Office office = await _officeRepository.FindByIdAsync(id);

            _mapper.Map<OfficeSaveDto, Office>(officeSaveDto, office);

            Office officeSaved = await _officeRepository.SaveAsync(office);

            return _mapper.Map<OfficeDto>(officeSaved);
        }

        public async Task<OfficeDto> DisabledAsync(int id)
        {
            Office office = await _officeRepository.FindByIdAsync(id);
            office.State = false;

            Office officeSaved = await _officeRepository.SaveAsync(office);

            return _mapper.Map<OfficeDto>(officeSaved);
        }
    }
}

