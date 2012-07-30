namespace Carbon.Caching
{
	using System;
	using System.Runtime.Caching;

    public sealed class DefaultCacheProvider : ICache
    {
		public bool Contains(string key)
		{
			return MemoryCache.Default[key] != null;
		}

		public object Get(string key)
		{
			return MemoryCache.Default.Get(key);
		}

		public T Get<T>(string key) 
		{
			return (T)MemoryCache.Default.Get(key);
		}

		public bool TryGet<T>(string key, out T data)
		{
			object cacheValue = MemoryCache.Default.Get(key);

			if (cacheValue != null) {
				data = (T)cacheValue;

				return true;
			}

			data = default(T);

			return false;
		}

        public void Set(string key, object value) 
		{
			MemoryCache.Default.Set(key, value, new CacheItemPolicy());
        }

		public void Set(string key, object value, DateTimeOffset absoluteExpiration)
		{
			MemoryCache.Default.Set(key, value, new CacheItemPolicy {
				AbsoluteExpiration = absoluteExpiration
			});
		}

        public bool Remove(string key)
		{
			return MemoryCache.Default.Remove(key) != null;
        }
    }
}