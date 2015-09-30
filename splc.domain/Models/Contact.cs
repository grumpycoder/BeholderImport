using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Contact : StateInfo
    {
        public Contact()
        {
            //this.AddressContactRels = new List<AddressContactRel>();
            //this.ChapterContactRels = new List<ChapterContactRel>();
            //this.ContactComments = new List<ContactComment>();
            //this.ContactContactRels = new List<ContactContactRel>();
            //this.ContactContactRels1 = new List<ContactContactRel>();
            //this.ContactEventRels = new List<ContactEventRel>();
            //this.ContactMediaAudioVideoRels = new List<ContactMediaAudioVideoRel>();
            //this.ContactMediaCorrespondenceRels = new List<ContactMediaCorrespondenceRel>();
            //this.ContactMediaImageRels = new List<ContactMediaImageRel>();
            //this.ContactMediaPublishedRels = new List<ContactMediaPublishedRel>();
            //this.ContactMediaWebsiteEGroupRels = new List<ContactMediaWebsiteEGroupRel>();
            //this.ContactNewsSourceRels = new List<ContactNewsSourceRel>();
            //this.ContactSubscriptionRels = new List<ContactSubscriptionRel>();
            //this.ContactVehicleRels = new List<ContactVehicleRel>();
            //this.OrganizationContactRels = new List<OrganizationContactRel>();
            //this.PersonContactRels = new List<PersonContactRel>();
        }

        [Key]
        public int Id { get; set; }
        public int CommonPersonId { get; set; }
        public int? ContactIdOld { get; set; }
        public string Profession { get; set; }
        [Display(Name = "Confidentiality Type")]
        public int? ConfidentialityTypeId { get; set; }
        [Display(Name = "Contact Type")]
        public int? ContactTypeId { get; set; }
        [Display(Name = "Contact Topic")]
        public int? ContactTopicId { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual ContactTopic ContactTopic { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual CommonPerson CommonPerson { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }

        public virtual ICollection<ContactComment> ContactComments { get; set; }
        public virtual ICollection<ContactMediaImageRel> ContactMediaImageRels { get; set; }
        public virtual ICollection<ChapterContactRel> ChapterContactRels { get; set; }
        public virtual ICollection<PersonContactRel> PersonContactRels { get; set; }
        public virtual ICollection<ContactContactRel> ContactContactRels { get; set; }
        public virtual ICollection<ContactContactRel> ContactContactRels2 { get; set; }
        public virtual ICollection<ContactMediaCorrespondenceRel> ContactMediaCorrespondenceRels { get; set; }
        public virtual ICollection<ContactSubscriptionRel> ContactSubscriptionRels { get; set; }
        public virtual ICollection<AddressContactRel> AddressContactRels { get; set; }
    }
}
