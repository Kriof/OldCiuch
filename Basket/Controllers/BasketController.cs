using AutoMapper;
using Basket.Entities;
using Basket.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private IBasketRepository _basketRepository;
        private IMapper _mapper;

        public BasketController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        // GET: BasketController
        public ActionResult All()
        {
            var basket = _basketRepository.GetAllBasket();
            return Ok(basket);
        }

        [HttpPost]
        public ActionResult AddToBasket(BasketItem basketItem)
        {
            var basket = _basketRepository.GetBasketById(basketItem.BasketId);

            basket = _basketRepository.AddProductToBasket(basket, basketItem.Item);

            return Ok(basket);
        }

        //// GET: BasketController/Details/5
        //public ActionResult Details(int id)
        //{
            
        //    return View();
        //}
    }
}
