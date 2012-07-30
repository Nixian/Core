namespace Carbon.Caching
{
	using System;

    public interface ICache
    {
		bool Contains(string key);

        object Get(string key);
		T Get<T>(string key);
		bool TryGet<T>(string key, out T data);
		
		void Set(string key, object data);
		void Set(string key, object data, DateTimeOffset absoluteExpiration);
        
		bool Remove(string key);
    }
}