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
    }
    public class ItemsRepository : IItemsRepository
    {
        private ItemsDbContext _itemsDbContext;

        public ItemsRepository(ItemsDbContext itemsDbContext)
        {
            _itemsDbContext = itemsDbContext;
        }
        public void GetAllItems()
        {
            
        }

        List<Item> IItemsRepository.GetAllItems()
        {
            return _itemsDbContext.Items.ToList();
        }
    }
}
