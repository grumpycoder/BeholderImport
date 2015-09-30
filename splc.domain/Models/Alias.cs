using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Alias : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Alias Name"), Required]
        public string AliasName { get; set; }

        public virtual ICollection<AliasChapterRel> AliasChapterRels { get; set; }
        public virtual ICollection<AliasOrganizationRel> AliasOrganizationRels { get; set; }
        public virtual ICollection<AliasPersonRel> AliasPersonRels { get; set; }
    }
}
