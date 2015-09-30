using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class LibraryCategoryType : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public decimal Number { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<MediaPublished> MediaPublisheds { get; set; }
    }
}
