using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UI.Models.Api;

namespace UI.Services
{
    public interface IItemsService
    {
        Task<List<Item>> GetItems();
        Task<Item> GetItem(int id);
    }
    public class ItemsService : IItemsService
    {
        private HttpClient _httpClient;

        public ItemsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Item> GetItem(int id)
        {
            var result = await _httpClient.GetAsync($"/item/GetItem?id={id}").ConfigureAwait(false);

            result.EnsureSuccessStatusCode();

            using var responseStream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync
                <Item>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }

        public async Task<List<Item>> GetItems()
        {
            var result = await _httpClient.GetAsync("/item/getallitems").ConfigureAwait(false);
            
            result.EnsureSuccessStatusCode();

            using var responseStream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync
                <List<Item>>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }
    }
}
