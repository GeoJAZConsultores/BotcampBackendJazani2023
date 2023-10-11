using Moq;
using AutoFixture;
using AutoMapper;
using Jazani.Application.Generals.Dtos.MineralTypes;
using Jazani.Application.Generals.Services;
using Jazani.Application.Generals.Services.Implementations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Application.Generals.Dtos.MineralTypes.Profiles;


namespace Jazani.UnitTest.Application.Generals.Services
{
    public class MineralTypeServiceTest
    {
        Mock<IMineralTypeRepository> _mockMineralTypeRepository;
        Mock<Microsoft.Extensions.Logging.ILogger<MineralTypeService>> _mockILogger;

        IMapper _mapper;
        Fixture _fixture;

        public MineralTypeServiceTest()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(c =>
            {
                c.AddProfile<MineralTypeProfile>();
            });

            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());


            _mockMineralTypeRepository = new Mock<IMineralTypeRepository>();

            _mockILogger = new Mock<Microsoft.Extensions.Logging.ILogger<MineralTypeService>>();
        }


        [Fact]
        public async void returnMineralTypeDtoWhenFindByIdAsync()
        {

            // Arrange
            MineralType mineralType = _fixture.Create<MineralType>();

            _mockMineralTypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mineralType);


            // Act
            IMineralTypeService mineralTypeService = new MineralTypeService(_mockMineralTypeRepository.Object, _mapper, _mockILogger.Object);


            MineralTypeDto mineralTypeDto = await mineralTypeService.FindByIdAsync(mineralType.Id);

            // Assert

            Assert.Equal(mineralType.Name, mineralTypeDto.Name);
        }

        [Fact]
        public async void returnMineralTypesDtoWhenFindAllAsync()
        {
            // Arrage
            IReadOnlyList<MineralType> mineralTypes = _fixture.CreateMany<MineralType>(5)
                .ToList();

            _mockMineralTypeRepository
                .Setup(r => r.FindAllAsync())
                .ReturnsAsync(mineralTypes);

            // Act
            IMineralTypeService mineralTypeService = new MineralTypeService(_mockMineralTypeRepository.Object, _mapper, _mockILogger.Object);

            IReadOnlyList<MineralTypeDto> mineralTypeDtos = await mineralTypeService.FindAllAsync();

            // Assert
            Assert.Equal(mineralTypes.Count, mineralTypeDtos.Count);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenCreateAsync()
        {

            // Arrage
            MineralType mineralType = new()
            {
                Id = 1,
                Name = "Metalico",
                Description = "Mineral metalico",
                Slug = "M",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockMineralTypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<MineralType>()))
                .ReturnsAsync(mineralType);


            // Act
            MineralTypeSaveDto mineralTypeSaveDto = new()
            {
                Name = mineralType.Name,
                Description = mineralType.Description,
                Slug = mineralType.Slug
            };

            IMineralTypeService mineralTypeService = new MineralTypeService(_mockMineralTypeRepository.Object, _mapper, _mockILogger.Object);

            MineralTypeDto mineralTypeDto = await mineralTypeService.CreateAsync(mineralTypeSaveDto);


            // Assert
            Assert.Equal(mineralType.Name, mineralTypeDto.Name);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenEditAsync()
        {

            // Arrage
            int id = 1;

            MineralType mineralType = new()
            {
                Id = id,
                Name = "Metalico",
                Description = "Mineral metalico",
                Slug = "M",
                State = true,
                RegistrationDate = DateTime.Now
            };

            _mockMineralTypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mineralType);

            _mockMineralTypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<MineralType>()))
                .ReturnsAsync(mineralType);

            // Act
            MineralTypeSaveDto mineralTypeSaveDto = new()
            {
                Name = mineralType.Name,
                Description = mineralType.Description,
                Slug = mineralType.Slug
            };

            IMineralTypeService mineralTypeService = new MineralTypeService(_mockMineralTypeRepository.Object, _mapper, _mockILogger.Object);

            MineralTypeDto mineralTypeDto = await mineralTypeService.EditAsync(id, mineralTypeSaveDto);


            // Assert
            Assert.Equal(mineralType.Id, mineralTypeDto.Id);
        }

        [Fact]
        public async void returnMineralTypeDtoWhenDisabledAsync()
        {

            // Arrage
            int id = 1;

            MineralType mineralType = new()
            {
                Id = id,
                Name = "Metalico",
                Description = "Mineral metalico",
                Slug = "M",
                State = false,
                RegistrationDate = DateTime.Now
            };


            _mockMineralTypeRepository
                .Setup(r => r.FindByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(mineralType);

            _mockMineralTypeRepository
                .Setup(r => r.SaveAsync(It.IsAny<MineralType>()))
                .ReturnsAsync(mineralType);

            // Act

            IMineralTypeService mineralTypeService = new MineralTypeService(_mockMineralTypeRepository.Object, _mapper, _mockILogger.Object);

            MineralTypeDto mineralTypeDto = await mineralTypeService.DisabledAsync(id);


            // Assert
            Assert.Equal(mineralType.State, mineralTypeDto.State);
        }

    }
}

