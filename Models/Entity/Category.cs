using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}