using System;
using System.Collections.Generic;
using System.Linq;

namespace splc.domain.Models
{
    public class DropdownPerson
    {
        public int Id { get; set; }
        public string label { get; set; }
    }

    public class DropdownPersons
    {
        public int Id { get; set; }
        public IQueryable<DropdownPerson> DropDownPersons { get; set; }
    }
}
