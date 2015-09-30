using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain.Models
{
    [Table("Beholder.v_MediaPublishedContext")]
    public partial class MediaPublishedContext_Index
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Context Text")]
        public string ContextText { get; set; }

        public int? MediaPublishedId { get; set; }

        public virtual MediaPublished MediaPublished { get; set; }

//        public virtual ICollection<MediaPublished> MediaPublisheds { get; set; }
    }
}
