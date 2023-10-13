using System;
using AutoMapper;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Core.Securities.Services;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;

        public UserService(IUserRepository userRepository, IMapper mapper, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _securityService = securityService;
        }

        public async Task<UserDto> CreateAsync(UserSaveDto saveDto)
        {
            User user = _mapper.Map<User>(saveDto);
            user.State = true;
            user.RegistrationDate = DateTime.Now;

            user.Password = _securityService.HashPassword(saveDto.Email, saveDto.Password);

            await _userRepository.SaveAsync(user);


            return _mapper.Map<UserDto>(user);
        }

        public Task<UserDto> EditAsync(int id, UserSaveDto saveDto)
        {
            throw new NotImplementedException();
        }
    }
}

