using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class NewsSource : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "News Source Name")]
        public string NewsSourceName { get; set; }
        [Display(Name = "News Source Type")]
        public int? NewsSourceTypeId { get; set; }

        public virtual NewsSourceType NewsSourceType { get; set; }
        public virtual ICollection<MediaImage> MediaImages { get; set; }
        public virtual ICollection<MediaAudioVideo> MediaAudioVideos { get; set; }
        public virtual ICollection<MediaPublished> MediaPublisheds { get; set; }
        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<NewsSourceComment> NewsSourceComments { get; set; }

    }
}
