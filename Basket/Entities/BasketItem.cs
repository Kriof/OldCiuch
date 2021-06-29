using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Entities
{
    public class BasketItem
    {
        public string BasketId { get; set; }
        public Item Item { get; set; }
    }
}
