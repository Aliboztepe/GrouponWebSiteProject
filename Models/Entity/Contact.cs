using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string Subject { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
        public int User_ID { get; set; }
        public User User { get; set; }

    }
}