namespace Core.CrossCuttingConcerns.Caching;

public interface ICacheManager
{
    T Get<T>(string key);
    object Get(string key);
    void Add(string key, object data, int timeout);
    void RemoveByKey(string key);
    void RemoveByPattern(string pattern);
    bool Any(string key);
    void Clear();
}