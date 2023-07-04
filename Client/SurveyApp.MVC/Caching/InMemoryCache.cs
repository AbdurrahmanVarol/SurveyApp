using Microsoft.Extensions.Caching.Memory;
using NuGet.Protocol;
using System.Text.Json;

namespace SurveyApp.MVC.Caching
{
    public class InMemoryCache : ICache
    {
        private readonly IMemoryCache _cache;

        public InMemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public T? Get<T>(string key) where T : class
        {
           

            if (_cache.TryGetValue(key, out object value))
            {
                return JsonSerializer.Deserialize<T>(value.ToString());
            }
            return null;
        }

        public string Get(string key)
        {

            if (_cache.TryGetValue(key, out object value))
            {
                return value.ToString();
            }
            return string.Empty;
        }      

        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public void Set(string key, string value)
        {
            _cache.Set(key, value);
        }

        public void Set<T>(string key, T value) where T : class
        {
            var serialized = JsonSerializer.Serialize(value);
            _cache.Set(key, serialized);
        }

        public void Set(string key, object value, TimeSpan expiration)
        {
            var serialized = JsonSerializer.Serialize(value);
            _cache.Set(key, serialized, expiration);
        }
       
    }
}
