using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MimeType : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<MediaCorrespondenceContext> MediaCorrespondenceContexts { get; set; }
        public virtual ICollection<MediaPublishedContext> MediaPublishedContexts { get; set; }
        public virtual ICollection<MediaWebsiteEGroupContext> MediaWebsiteEGroupContexts { get; set; }
    }
}
