using Groupon.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Groupon.Models.Context
{
    public class GrouponContext:DbContext
    {
        public GrouponContext():base("GrouponDb")
        {

        }
        
        public DbSet<About> About { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
      
        public DbSet<OrderLine> OrderLines { get; set; }


  



        
    }
}