using Basket.DbContexts;
using Basket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Repositories
{
    public interface IBasketRepository
    {
        public List<Entities.Basket> GetAllBasket();
        public Entities.Basket GetBasketById(string basketId);
        public Entities.Basket AddProductToBasket(Entities.Basket basket, Item item);
    }
    public class BasketRepository : IBasketRepository
    {
        private BasketDbContext _basketDbContext;

        public BasketRepository(BasketDbContext basketDbContext)
        {
            _basketDbContext = basketDbContext;
        }

        public Entities.Basket AddProductToBasket(Entities.Basket basket, Item item)
        {
            
            var basketDbContxt = _basketDbContext.Basket.FirstOrDefault(x => x.BasketId == basket.BasketId);

            if(!basketDbContxt.Items.Any(x => x.Id == item.Id))
            {
                basketDbContxt.Items.Add(item);
                basketDbContxt.Count = basketDbContxt.Items.Count();
                basketDbContxt.Price = basketDbContxt.Items.Select(x => x.Price).Sum();
                _basketDbContext.Basket.Update(basketDbContxt);
            }

            return basketDbContxt;
        }

        public void GetAllBasket()
        {
            
        }

        public Entities.Basket GetBasketById(string basketId)
        {
            var basket = _basketDbContext.Basket.FirstOrDefault(x => x.BasketId == basketId) ?? new Entities.Basket();

            if(basket.BasketId == null)
            {
                basket.BasketId = basketId;
                _basketDbContext.Add(basket);
                _basketDbContext.SaveChanges();
            }

            return basket;
        }

        List<Entities.Basket> IBasketRepository.GetAllBasket()
        {
            return _basketDbContext.Basket.ToList();
        }
    }
}
