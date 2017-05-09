using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lexiphone.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }
        public List<OrderRow> OrderRows { get; set; }

    }
}