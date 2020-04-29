namespace DBA.Application.Services.Interfaces
{
    public interface ICacheAppService
    {
        void Set<T>(string key, T value);
        T Get<T>(string key);
    }
}
