using BookStore.Bussiness.Abstract;
using BookStore.Entities.BasketEntities;
using StackExchange.Redis;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class BasketManager : IBasketService
    {
        private readonly IDatabase _database;

        public BasketManager(IConnectionMultiplexer connection)
        {
            _database = connection.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        public async Task<Basket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(data);
        }

        public async Task<Basket> UpdateBasketAsync(Basket basketItem)
        {
            var created = await _database.StringSetAsync(basketItem.Id, JsonSerializer.Serialize(basketItem), TimeSpan.FromDays(3));

            if (!created) return null;
            return await GetBasketAsync(basketItem.Id);
        }
    }
}
