using MinimalAPIAuthentication.Models;

namespace MinimalAPIAuthentication.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Task<User> Login(string userName, string hashedPassword)
        {
            throw new NotImplementedException();
        }
    }
}
