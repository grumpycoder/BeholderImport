using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ConfidentialityType : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<BeholderPerson> BeholderPersons { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<MediaImage> MediaImages { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<MediaAudioVideo> MediaAudioVideos { get; set; }
        public virtual ICollection<MediaCorrespondence> MediaCorrespondences { get; set; }
        public virtual ICollection<MediaPublished> MediaPublisheds { get; set; }
        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}
