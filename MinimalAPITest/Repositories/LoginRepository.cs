using MinimalAPIAuthentication.Models;

namespace MinimalAPIAuthentication.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public Task<User> Login(string userName, string hashedPassword)
        {
            ////TODO: Implement
            throw new NotImplementedException();
        }
    }
}
