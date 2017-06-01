using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lexiphone.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Current Price")]
        public decimal CurrentPrice { get; set; }
        public int Stock { get; set; }
        [Display(Name ="Photo")]
        public string ProductUrl { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<OrderRow> OrderRows { get; set; }



    }
}