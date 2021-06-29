using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Api;

namespace UIPages.Models.Api
{
    public class Basket
    {
        [Required]
        public string BasketId { get; set; }

        public List<Item> Items { get; set; }

        public double Price { get; set; }

    }
}
