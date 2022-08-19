using MinimalAPIAuthentication.Models;
using MinimalAPIAuthentication.Repositories;
using MinimalAPIAuthentication.Services;

namespace MinimalAPITest.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        private IHashService _hashService;
        private ILoginRepository _loginRepository;

        public AuthenticationService(IHashService hashService, ILoginRepository loginRepository)
        {
            _hashService = hashService;
            _loginRepository = loginRepository;
        }

        public async Task<User> Authenticate(string email, string password)
        {
            return await _loginRepository.Login(email, _hashService.GetHash(password));
        }
    }
}
