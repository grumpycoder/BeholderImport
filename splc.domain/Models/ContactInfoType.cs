using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ContactInfoType : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<ChapterContactInfoRel> ChapterContactInfoRels { get; set; }
        public virtual ICollection<ContactInfoPersonRel> ContactInfoPersonRels { get; set; }
    }
}
