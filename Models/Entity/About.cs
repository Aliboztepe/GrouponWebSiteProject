using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class About
    {

        [Key]
        public int AboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}