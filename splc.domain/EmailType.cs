using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace splc.domain
{
    public class EmailType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
