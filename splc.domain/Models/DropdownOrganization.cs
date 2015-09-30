using System;
using System.Collections.Generic;
using System.Linq;

namespace splc.domain.Models
{
    public class DropdownOrganization
    {
        public int Id { get; set; }
        public string label { get; set; }
    }

    public class DropdownOrganizations
    {
        public int Id { get; set; }
        public IQueryable<DropdownOrganization> DropDownOrganizations { get; set; }
    }
}
