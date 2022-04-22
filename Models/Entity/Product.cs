using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string SalePercent { get; set; }
      

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; }

        public string Description { get; set; }

       
    }
}