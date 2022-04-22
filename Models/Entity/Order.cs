using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public string FullName { get; set; }
        
        public string AdresBasligi { get; set; }
       
        public string Adres { get; set; }
        
        public string Sehir { get; set; }
        
        public string Semt { get; set; }
        
        public string Mahalle { get; set; }
      
        public string PostaKodu { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
   
    }

    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}