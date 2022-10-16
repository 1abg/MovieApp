namespace MovieApp.Infrastructure.Caching.Abstract
{
    public interface ICacheService
    {
        Task<string> GetValueAsync(string key);
        Task<bool> SetValueAsync(string key, string value, TimeSpan ExpireTime);
        Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> action, TimeSpan ExpireTime) where T : class;
        T GetOrAdd<T>(string key, Func<T> action, TimeSpan ExpireTime) where T : class;
        Task Clear(string key);
        void ClearAll();
    }
}
