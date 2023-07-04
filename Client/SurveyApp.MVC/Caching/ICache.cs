namespace SurveyApp.MVC.Caching
{
    public interface ICache
    {
        void Set(string key, string value);

        void Set<T>(string key, T value) where T : class;

        void Set(string key, object value, TimeSpan expiration);      

        T? Get<T>(string key) where T : class;

        string Get(string key);

        void Remove(string key);
    }
}
