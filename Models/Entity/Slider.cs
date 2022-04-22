using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Groupon.Models.Entity
{
    public class Slider
    {
        [Key]
        public int SliderID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
    }
}