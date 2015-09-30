using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace splc.domain
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int PhoneTypeId { get; set; }
        public virtual PhoneType PhoneType { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}
