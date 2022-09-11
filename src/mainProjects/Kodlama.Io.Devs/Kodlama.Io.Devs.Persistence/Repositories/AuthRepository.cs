using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.JWT;
using Kodlama.Io.Devs.Application.Services.Repositories;
using Kodlama.Io.Devs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.Io.Devs.Persistence.Repositories
{
    public class AuthRepository :IAuthRepository
    {

        private readonly BaseDbContext _context;
        private readonly IUserRepository _userRepository;

        private readonly ITokenHelper _tokenHelper;
        public AuthRepository(BaseDbContext context, IUserRepository userRepository, ITokenHelper tokenHelper)
        {
            _context = context;
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _userRepository.GetAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }

            return true;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
        
        public async Task<AccessToken> CreateAccessToken(User user)
        {
            List<OperationClaim> operationClaims = await _userRepository.GetUserClaims(user.Id);
            AccessToken token = _tokenHelper.CreateToken(user,operationClaims);
            return token;
        }
    }
   
}