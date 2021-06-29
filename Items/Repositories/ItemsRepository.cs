using Items.DbContexts;
using Items.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Repositories
{
    public interface IItemsRepository
    {
        public List<Item> GetAllItems();
        public Item GetItemById(int id);
    }
    public class ItemsRepository : IItemsRepository
    {
        private ItemsDbContext _itemsDbContext;

        public ItemsRepository(ItemsDbContext itemsDbContext)
        {
            _itemsDbContext = itemsDbContext;
        }

        public Item GetItemById(int id)
        {
            return _itemsDbContext.Items.FirstOrDefault(x => x.Id == id);
        }

        List<Item> IItemsRepository.GetAllItems()
        {
            return _itemsDbContext.Items.ToList();
        }
    }
}
