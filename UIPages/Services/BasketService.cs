using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using UI.Models.Api;
using UIPages.Models.Api;

namespace UIPages.Services
{
    public interface IBasketService
    {
        //public string GetCardId();
        Task<Basket> AddProductToBasket(Item item, string username);
    }
    public class BasketService : IBasketService
    {
        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public string cardId = "CartId";
        private HttpClient _httpClient;

        public async Task<Basket> AddProductToBasket(Item item, string username)
        {
            var serialized = JsonConvert.SerializeObject(new BasketItem
            {
                Item = item,
                Username = username
            });
            HttpContent hc = new StringContent(serialized);
            hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await _httpClient.PostAsync($"basket/AddToBasket", hc).ConfigureAwait(false);

            var resultString = await result.Content.ReadAsStringAsync().ConfigureAwait(false);
            var basket = JsonConvert.DeserializeObject<Basket>(resultString);
            return basket;
        }
    }
    
}
