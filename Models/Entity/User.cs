using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string password { get; set; }
        public string passwordAgain { get; set; }

        
        public string PasswordChange { get; set; }

        public ICollection<Contact> Contacts { get; set; }

    }
}