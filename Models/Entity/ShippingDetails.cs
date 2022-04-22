using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class ShippingDetails
    {
        [Key]
        public int ShippingId { get; set; }
        [Required(ErrorMessage = "Please enter a Name and Surname.")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Please enter an adress header.")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Please enter an adress.")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Please enter a City.")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Please enter a Town.")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "Please enter a Neighborhood.")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "Please enter a Post Code.")]
        public string PostaKodu { get; set; }
    }
}