using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace splc.domain
{
    public class EmailAddress
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public int EmailTypeId { get; set; }
        public virtual EmailType EmailType { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }

    }
}
