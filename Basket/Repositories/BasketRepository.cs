using Basket.DbContexts;
using Basket.Entities;
using Microsoft.EntityFrameworkCore;
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
        public Entities.Basket GetBasketByUserName(string userName);
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
            //var basketEntity = basket;
            using (var context = _basketDbContext)
            {
                var basketEntity = context.Basket.Include(x => x.Items).FirstOrDefault(y => y.BasketId == basket.BasketId);
                if (!basketEntity.Items.Any(x => x.Id == item.Id))
                {

                    basketEntity.Items.Add(item);

                    basketEntity.Count = basket.Items.Count();
                    basketEntity.Price = basket.Items.Select(x => x.Price).Sum();

                    context.Basket.Update(basketEntity);
                    //context.SaveChanges();

                }

            }

            return basket;
        }

        //    if (!basketEntity.Items.Any(x => x.Id == item.Id))
        //    {

        //        basketEntity.Items.Add(item);

        //        basketEntity.Count = basket.Items.Count();
        //        basketEntity.Price = basket.Items.Select(x => x.Price).Sum();

        //        _basketDbContext.Basket.Update(basketEntity);


        //        try
        //        {
        //            // Attempt to save changes to the database
        //            _basketDbContext.SaveChanges();

        //        }
        //        catch (DbUpdateConcurrencyException ex)
        //        {
        //            foreach (var entry in ex.Entries)
        //            {
        //                var test = "";
        //            }
        //        }
        //        _basketDbContext.SaveChanges();
        //    }

        //    return basket;
        //}

        public void GetAllBasket()
        {
            
        }

        public Entities.Basket GetBasketByUserName(string userName)
        {
            var basket = _basketDbContext.Basket.FirstOrDefault(x => x.Username == userName) ?? new Entities.Basket();

            bool isNew = false;
            basket.Username = userName;
            if (basket.BasketId == null)
            {
                isNew = true;
                basket.BasketId = Guid.NewGuid().ToString();
            }
                
            if (isNew)
            {
                _basketDbContext.Add(basket);
            }
            else
            {
                //_basketDbContext.Basket.Update(basket);
            }
            


            return basket;
        }

        List<Entities.Basket> IBasketRepository.GetAllBasket()
        {
            return _basketDbContext.Basket.ToList();
        }
    }
}
