using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lexiphone.Models
{
    public class Brand
    {
        [Display(Name = "Brand ")]
        public int BrandId { get; set; }
        [Display (Name = "Brand Name")]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}