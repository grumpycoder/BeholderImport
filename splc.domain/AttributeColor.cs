using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace splc.domain
{
    public class AttributeColor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Color")]
        public string Name { get; set; }
    }
}
