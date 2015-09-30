using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ContactInfo : StateInfo
    {
        public ContactInfo()
        {
            //this.ContactChapterRels = new List<ContactChapterRel>();
            //this.ContactPersonRels = new List<ContactInfoPersonRel>();
        }

        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact is Required")]
        [Display(Name = "Contact")]
        public string Contact { get; set; }
        [Display(Name = "Extension")]
        public string Extension { get; set; }

        public virtual ICollection<ContactInfoPersonRel> ContactInfoPersonRels { get; set; }
        public virtual ICollection<ChapterContactInfoRel> ChapterContactInfoRels { get; set; }
    }
}
