using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ChapterType : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Chapter Type")]
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }
    }
}
