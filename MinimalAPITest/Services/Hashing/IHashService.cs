namespace MinimalAPIAuthentication.Services
{
    public interface IHashService
    {
        public string GetHash(string key);
    }
}
