using AutoMapper;
using Jazani.Application.Generals.Dtos.Minerals;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class MineralService : IMineralService
    {

        private readonly IMineralRepository _mineralRepository;
        private readonly IMapper _mapper;

        public MineralService(IMineralRepository mineralRepository, IMapper mapper)
        {
            _mineralRepository = mineralRepository;
            _mapper = mapper;
        }

        public async Task<MineralDto> CreateAsync(MineralSaveDto saveDto)
        {
            Mineral mineral = _mapper.Map<Mineral>(saveDto);
            mineral.RegistrationDate = DateTime.Now;
            mineral.State = true;

            await _mineralRepository.SaveAsync(mineral);

            return _mapper.Map<MineralDto>(mineral);
        }

        public async Task<MineralDto> DisabledAsync(int id)
        {
            Mineral mineral = await _mineralRepository.FindByIdAsync(id);
            mineral.State = false;

            await _mineralRepository.SaveAsync(mineral);

            return _mapper.Map<MineralDto>(mineral);
        }

        public async Task<MineralDto> EditAsync(int id, MineralSaveDto saveDto)
        {
            Mineral mineral = await _mineralRepository.FindByIdAsync(id);

            _mapper.Map<MineralSaveDto, Mineral>(saveDto, mineral);

            await _mineralRepository.SaveAsync(mineral);

            return _mapper.Map<MineralDto>(mineral);
        }

        public async Task<IReadOnlyList<MineralDto>> FindAllAsync()
        {
            IReadOnlyList<Mineral> minerals = await _mineralRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MineralDto>>(minerals);
        }

        public async Task<MineralDto?> FindByIdAsync(int id)
        {
            Mineral mineral = await _mineralRepository.FindByIdAsync(id);

            return _mapper.Map<MineralDto>(mineral);
        }
    }
}

