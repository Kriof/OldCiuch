using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Items.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,4)")]
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public int CategoryId { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Category Category { get; set; }
        public string Color { get; set; }

    }
}
