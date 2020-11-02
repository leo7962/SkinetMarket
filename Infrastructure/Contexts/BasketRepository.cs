using Core.Interfaces;
using Core.Models;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _connection;

        public BasketRepository(IConnectionMultiplexer connection)
        {
            _connection = connection.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _connection.KeyDeleteAsync(basketId);
        }

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            RedisValue data = await _connection.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            bool created = await _connection.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if (!created)
            {
                return null;
            }

            return await GetBasketAsync(basket.Id);
        }
    }
}
