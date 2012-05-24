using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


namespace AngiesList.Redis
{
    public class RedisBucketConfiguration : RedisConfiguration
    {
        public RedisBucketConfiguration() : base()
        { }
        /// <summary>
        /// Create a RedisBucketConfiguration from existing RedisConfiguration
        /// </summary>
        /// <param name="redisConfig"></param>
        /// <param name="name"></param>
        public RedisBucketConfiguration(RedisConfiguration redisConfig, string name)
        {
            Host = redisConfig.Host;
            Port = redisConfig.Port;
            Name = name;
        }
        public RedisBucketConfiguration(string name, string host, int? port) 
        {
            Name = name;
            Host = host;
            if (port.HasValue) Port = port.Value;
        }


        public string Name { get; set; }


    }
}