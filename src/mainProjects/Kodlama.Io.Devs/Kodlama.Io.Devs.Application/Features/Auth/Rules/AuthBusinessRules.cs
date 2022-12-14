using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Kodlama.Io.Devs.Application.Services.Repositories;

namespace Kodlama.Io.Devs.Application.Features.Auth.Rules
{
    public class AuthBusinessRules
    {
        IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void CheckIfUserExists(User user)
        {
                if(user == null)
                    throw new BusinessException("User not found.");
        }

        public async Task UsernameShouldNotBeDuplicated(string username)
        {
            if (await _userRepository.GetAsync(x => x.Username == username) != null)
            {
                throw new BusinessException("Username is already taken.");
            }
        }
        public async Task EmailShouldNotBeDuplicated(string email)
        {
            if (await _userRepository.GetAsync(x => x.Email == email) != null)
            {
                throw new BusinessException("Email is already taken.");
            }
        }
    }
}