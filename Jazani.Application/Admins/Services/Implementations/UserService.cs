using System;
using AutoMapper;
using Jazani.Application.Admins.Dtos.Users;
using Jazani.Application.Cores.Exceptions;
using Jazani.Core.Securities.Services;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Microsoft.Extensions.Configuration;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ISecurityService _securityService;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, ISecurityService securityService, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _securityService = securityService;
            _configuration = configuration;
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

        public async Task<UserSecurityDto> LoginAsync(UserAuthDto userAuth)
        {

            User? user = await _userRepository.FindByEmailAsync(userAuth.Email);

            if(user is null) throw new NotFoundCoreException("Usuario no esta registrado en nuestro Sistema");

            bool isCorrect = _securityService.VerifyHashedPassword(user.Email, user.Password, userAuth.Password);

            if(!isCorrect) throw new NotFoundCoreException("La contraseña que ingreso no es correcta");


            if(!user.State) throw new NotFoundCoreException("Usuario no esta activo. Comuniquese con el adminstrador");

            UserSecurityDto userSecurity = _mapper.Map<UserSecurityDto>(user);

            string jwtSecretKey = _configuration.GetSection("Security:JwtSecrectKey").Get<string>();

            userSecurity.Security = _securityService.JwtSecurity(jwtSecretKey);


            return userSecurity;
        }
    }
}

