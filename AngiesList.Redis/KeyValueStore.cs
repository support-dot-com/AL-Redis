using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;

namespace AngiesList.Redis
{
    public sealed class KeyValueStore
    {
        private static ConcurrentDictionary<string, Bucket> bucketsPool = new ConcurrentDictionary<string, Bucket>();
        private static readonly object locker = new Object();

        private KeyValueStore() { }

        /// <summary>
        /// Create a bucket using the specified redis connection.
        /// Note: Breaking API change: passing null,null for host,port 
        /// no longer reads the config file. Please use Bucket(name) 
        /// instead.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public static Bucket Bucket(string name, string host, int? port)
        {
            return Bucket(new RedisBucketConfiguration(name, host, port));
        }

        public static Bucket Bucket(RedisBucketConfiguration config)
        {
            var poolKey = config.Name + config.Host + config.Port;
            if (!bucketsPool.ContainsKey(poolKey))
            {
                lock (locker)
                {
                    bucketsPool.TryAdd(poolKey, new RedisBucket(config.Name, config.Host, config.Port));
                }
            }
            return bucketsPool[poolKey];
        }

        /// <summary>
        /// Read the default configuration file for host/port
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Bucket Bucket(string name)
        {
            var config = (RedisBucketConfiguration)RedisConfiguration.ReadConfigFile();
            config.Name = name;
            return Bucket(config);
        }
    }
}
