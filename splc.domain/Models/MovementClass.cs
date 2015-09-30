using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MovementClass : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Movement Class")]
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<BeholderPerson> BeholderPersons { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<MediaImage> MediaImages { get; set; }
        public virtual ICollection<MediaAudioVideo> MediaAudioVideos { get; set; }
        public virtual ICollection<MediaCorrespondence> MediaCorrespondences { get; set; }
        public virtual ICollection<MediaPublished> MediaPublisheds { get; set; }
        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
