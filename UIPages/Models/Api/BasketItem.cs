using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Api;

namespace UIPages.Models.Api
{
    public class BasketItem
    {
        public string BasketId { get; set; }
        public Item Item { get; set; }
        public string Username { get; set; }

    }
}
