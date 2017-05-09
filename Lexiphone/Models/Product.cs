using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lexiphone.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Current Price")]
        public float CurrentPrice { get; set; }
        public int Stock { get; set; }
        [Required]
        public string Category { get; set; }
        public List<OrderRow> OrderRows { get; set; }


    }
}