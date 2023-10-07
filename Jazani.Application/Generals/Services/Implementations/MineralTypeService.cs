using AutoMapper;
using Jazani.Application.Cores.Exceptions;
using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Core.Paginations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class MineralTypeService : IMineralTypeService
    {
        private readonly IMineralTypeRepository _mineralTypeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MineralTypeService> _logger;

        public MineralTypeService(IMineralTypeRepository mineralTypeRepository, IMapper mapper, ILogger<MineralTypeService> logger)
        {
            _mineralTypeRepository = mineralTypeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<MineralTypeDto> CreateAsync(MineralTypeSaveDto saveDto)
        {
            MineralType mineralType = _mapper.Map<MineralType>(saveDto);
            mineralType.RegistrationDate = DateTime.Now;
            mineralType.State = true;

            await _mineralTypeRepository.SaveAsync(mineralType);

            return _mapper.Map<MineralTypeDto>(mineralType);
        }

        public async Task<MineralTypeDto> DisabledAsync(int id)
        {
            MineralType? mineralType = await _mineralTypeRepository.FindByIdAsync(id);

            if (mineralType is null) throw MineralTypeNotFound(id);

            mineralType.State = false;

            await _mineralTypeRepository.SaveAsync(mineralType);

            return _mapper.Map<MineralTypeDto>(mineralType);
        }

        public async Task<MineralTypeDto> EditAsync(int id, MineralTypeSaveDto saveDto)
        {
            MineralType? mineralType = await _mineralTypeRepository.FindByIdAsync(id);

            if (mineralType is null) throw MineralTypeNotFound(id);

            _mapper.Map<MineralTypeSaveDto, MineralType>(saveDto, mineralType);

            await _mineralTypeRepository.SaveAsync(mineralType);

            return _mapper.Map<MineralTypeDto>(mineralType);
        }

        public async Task<IReadOnlyList<MineralTypeDto>> FindAllAsync()
        {
            IReadOnlyList<MineralType> mineralTypes = await _mineralTypeRepository.FindAllAsync();

            return _mapper.Map<IReadOnlyList<MineralTypeDto>>(mineralTypes);
        }

        public async Task<MineralTypeDto?> FindByIdAsync(int id)
        {
            MineralType? mineralType = await _mineralTypeRepository.FindByIdAsync(id);

            if (mineralType is null)
            {
                _logger.LogWarning("Tipo de mineral no encontrado para el id: " + id);
                throw MineralTypeNotFound(id);
            }

            _logger.LogInformation("Tipo de minaral {name}", mineralType.Name);

            return _mapper.Map<MineralTypeDto>(mineralType);
        }

        public async Task<ResponsePagination<MineralTypeDto>> PaginatedSearch(RequestPagination<MineralTypeFilterDto> request)
        {
            var entity = _mapper.Map<RequestPagination<MineralType>>(request);
            var response = await _mineralTypeRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<MineralTypeDto>>(response);
        }



        private NotFoundCoreException MineralTypeNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de mineral no encontrado para el id: " + id);
        }
    }
}

