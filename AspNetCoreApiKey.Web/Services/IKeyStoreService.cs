namespace AspNetCoreApiKey.Web.Services
{
    public interface IKeyStoreService
    {
        bool IsValidKey(string key);
    }
}
