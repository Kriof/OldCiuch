using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Entities
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
