using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Entities
{
    public class Basket
    {
        public Basket()
        {
            Items = new List<Item>();
        }
        [Required]
        public string BasketId { get; set; }
        [Required]
        public List<Item> Items { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

    }
}
