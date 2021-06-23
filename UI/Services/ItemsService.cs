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
    }
    public class ItemsService : IItemsService
    {
        private HttpClient _httpClient;

        public ItemsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Item>> GetItems()
        {
            var result = await _httpClient.GetAsync("/item/all").ConfigureAwait(false);
            
            result.EnsureSuccessStatusCode();

            using var responseStream = await result.Content.ReadAsStreamAsync().ConfigureAwait(false);
            return await JsonSerializer.DeserializeAsync
                <List<Item>>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).ConfigureAwait(false);
        }
    }
}
