using MinimalAPIAuthentication.Models;

namespace MinimalAPIAuthentication.Repositories
{
    public interface ILoginRepository
    {
        Task<User> Login(string userName, string hashedPassword);

    }
}
