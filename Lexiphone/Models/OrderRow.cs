using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lexiphone.Models
{
    public class OrderRow
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Orders { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Purchase price ")]
        public decimal PurchasePrise { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }

    }
}