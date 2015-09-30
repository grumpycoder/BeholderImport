using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class OrganizationType : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Type")]
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }
    }
}
