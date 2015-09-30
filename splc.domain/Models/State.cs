using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class State
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "State Code")]
        public string StateCode { get; set; }
        [Display(Name = "State Name")]
        public string StateName { get; set; }
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        [Display(Name = "Created User")]
        public int CreatedUserId { get; set; }
        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }
        [Display(Name = "Modified User")]
        public int? ModifiedUserId { get; set; }

        public virtual ICollection<CommonPerson> CommonPersons { get; set; }
        public virtual ICollection<MediaImage> MediaImages { get; set; }
        public virtual ICollection<MediaAudioVideo> MediaAudioVideos { get; set; }
        public virtual ICollection<MediaCorrespondence> MediaCorrespondences { get; set; }
        public virtual ICollection<MediaPublished> MediaPublisheds { get; set; }
        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<VehicleTag> VehicleTags { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User ModifiedUser { get; set; }
    }
}
