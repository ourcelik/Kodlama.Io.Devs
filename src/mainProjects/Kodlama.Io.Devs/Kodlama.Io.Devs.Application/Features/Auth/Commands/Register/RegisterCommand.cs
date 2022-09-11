using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Features.Auth.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<UserForRegisterDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserForRegisterDto>
        {
            private readonly IAuthRepository _authRepository;
            private readonly IMapper _mapper;

            private readonly AuthBusinessRules _authBusinessRules;

            public RegisterCommandHandler(IAuthRepository authRepository, IMapper mapper, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
            {
                _authRepository = authRepository;
                _mapper = mapper;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<UserForRegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);

                Task duplicatedEmail = _authBusinessRules.EmailShouldNotBeDuplicated(user.Email);
                Task duplicatedUsername = _authBusinessRules.UsernameShouldNotBeDuplicated(user.Username);
                await Task.WhenAll(duplicatedEmail, duplicatedUsername);
                User createdUser = await _authRepository.Register(user, request.Password);
                var mappedUser = _mapper.Map<UserForRegisterDto>(createdUser);
                mappedUser.Token = await _authRepository.CreateAccessToken(createdUser);
                
                return mappedUser;
            }
        }
    }
}
