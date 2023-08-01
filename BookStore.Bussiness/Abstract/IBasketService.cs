using BookStore.Entities.BasketEntities;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IBasketService
    {
        Task<Basket> GetBasketAsync(string basketId);
        Task<Basket> UpdateBasketAsync(Basket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
