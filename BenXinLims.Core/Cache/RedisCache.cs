using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Furion.DependencyInjection;
using Furion;
using Newtonsoft.Json;
using StackExchange.Redis;
using BenXinLims.Core.CONST;

namespace BenXinLims.Core.Cache
{
    public class RedisCache : ISingleton
    {
        private readonly string redisPrefix = CacheConst.SYS_PREFIX;
        private readonly ConnectionMultiplexer _redis;
        private readonly IDatabase _db;
        public RedisCache()
        {
            //string redisConnectionString = App.GetConfig<string>("RedisConnectionString");
            //string redisPrefix = App.GetConfig<string>("RedisPrefix");
            // redisPrefix = _redisPrefix;

            string redisConnectionString = App.Configuration["cache:RedisConnectionString"];

            _redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _db = _redis.GetDatabase(0);
        }

        public bool Del(params string[] key)
        {

            return _db.KeyDelete(redisPrefix + key);
        }

        public async Task<bool> DelAsync(params string[] key)
        {

            return await _db.KeyDeleteAsync(redisPrefix + key);
        }

        public async Task<long> DelByPatternAsync(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
                return default;

            var keys = _redis.GetServer(_redis.GetEndPoints().First()).Keys(pattern: redisPrefix + pattern + "*");

            if (keys != null && keys.Any())
            {

                return await _db.KeyDeleteAsync(keys.ToArray());
            }

            return default;
        }

        public bool Exists(string key)
        {

            return _db.KeyExists(redisPrefix + key);
        }

        public async Task<bool> ExistsAsync(string key)
        {

            return await _db.KeyExistsAsync(redisPrefix + key);
        }

        public string Get(string key)
        {

            return _db.StringGet(redisPrefix + key);
        }

        public T Get<T>(string key)
        {

            var value = _db.StringGet(redisPrefix + key);
            return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : default;
        }

        public async Task<string> GetAsync(string key)
        {

            return await _db.StringGetAsync(redisPrefix + key);
        }

        public async Task<T> GetAsync<T>(string key)
        {

            var value = await _db.StringGetAsync(redisPrefix + key);
            return value.HasValue ? JsonConvert.DeserializeObject<T>(value) : default;
        }

        public bool Set(string key, object value)
        {

            return _db.StringSet(redisPrefix + key, JsonConvert.SerializeObject(value));
        }

        public bool Set(string key, object value, TimeSpan expire)
        {

            return _db.StringSet(redisPrefix + key, JsonConvert.SerializeObject(value), expire);
        }

        public async Task<bool> SetAsync(string key, object value)
        {

            return await _db.StringSetAsync(redisPrefix + key, JsonConvert.SerializeObject(value));
        }

        public async Task<bool> SetAsync(string key, object value, TimeSpan expire)
        {

            return await _db.StringSetAsync(redisPrefix + key, JsonConvert.SerializeObject(value), expire);
        }

        public List<string> GetAllKeys()
        {
            var keys = new List<string>();
            var server = _redis.GetServer(_redis.GetEndPoints().First());

            foreach (var key in server.Keys(pattern: redisPrefix + "*"))
            {
                keys.Add(key);
            }

            return keys;
        }
    }
}
