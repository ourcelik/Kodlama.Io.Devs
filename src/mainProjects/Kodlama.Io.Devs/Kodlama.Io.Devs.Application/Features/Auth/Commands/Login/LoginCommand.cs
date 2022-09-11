using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.Io.Devs.Application.Features.Auth.Rules;
using Kodlama.Io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.Io.Devs.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<UserForLoginDto>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, UserForLoginDto>
        {
            private readonly IAuthRepository _authRepository;
            private readonly IMapper _mapper;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IMapper mapper, IAuthRepository authRepository, AuthBusinessRules authBusinessRules)
            {
                _mapper = mapper;
                _authRepository = authRepository;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<UserForLoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var user = await _authRepository.Login(request.Username, request.Password);
                _authBusinessRules.CheckIfUserExists(user);
                UserForLoginDto userForLoginDto = _mapper.Map<UserForLoginDto>(user);
                userForLoginDto.AccessToken = await _authRepository.CreateAccessToken(user);
                
                return userForLoginDto;

            }
        }
    }
}
