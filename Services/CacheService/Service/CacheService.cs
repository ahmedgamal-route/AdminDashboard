using Services.CacheService.Interface;
using StackExchange.Redis;
using System.Text.Json;

namespace Services.CacheService.Service
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _dataBase;
        public CacheService(IConnectionMultiplexer redis) 
        {
            _dataBase = redis.GetDatabase();

        }
        public async Task<string> SetCasheResponseAsync(string cachKey, object response, TimeSpan timeToLive)
        {
            if (response is null)
                return null;

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var serializedResponse = JsonSerializer.Serialize(response, options);

            await _dataBase.StringSetAsync(cachKey, serializedResponse, timeToLive);

            return await GetCasheResponseAsync(cachKey);

        }

        public async Task<string> GetCasheResponseAsync(string cashKey)
        {
            var cachedResponse = await _dataBase.StringGetAsync(cashKey);

            if (cachedResponse.IsNullOrEmpty)
                return null;
            
            return cachedResponse;
        }

    }
}
