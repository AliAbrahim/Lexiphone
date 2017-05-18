﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lexiphone.Models
{
    public class Order
    {
        //public int Id { get; set; }
        //public int CustomerId { get; set; }
        //public Customer Customers { get; set; }
        [Required]
        [Display(Name = "Order Date")]
        //public DateTime? OrderDate { get; set; }
        //public List<OrderRow> OrderRows { get; set; }

        [Key]
        public int OrderId { get; set; }

        [Required]
        [Display(Name ="User Name")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        [Required]
        [Display(Name = "Postal Code ")]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public decimal Total { get; set; }
        public System.DateTime OrderDate { get; set; }

        public List<OrderRow> OrderRows { get; set; }








    }
}