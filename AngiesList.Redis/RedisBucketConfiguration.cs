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

        public RedisBucketConfiguration(string name, string host, int? port) 
        {
            Name = name;
            Host = host;
            if (port.HasValue) Port = port.Value;
        }


        public string Name { get; set; }


    }
}