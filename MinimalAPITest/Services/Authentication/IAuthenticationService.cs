using MinimalAPIAuthentication.Models;

namespace MinimalAPITest.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<User> Authenticate(string email, string password);

    }
}
