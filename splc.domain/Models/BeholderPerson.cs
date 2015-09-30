using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain.Models
{
    public partial class BeholderPerson : StateInfo
    {
        public BeholderPerson()
        {
            //this.OrganizationPersonRels = new List<OrganizationPersonRel>();
            //this.ChapterPersonRels = new List<ChapterPersonRel>();
            //this.PersonScreenNames = new List<PersonScreenName>();
            //this.PersonMediaImageRels = new List<PersonMediaImageRel>();
            //this.PersonComments = new List<PersonComment>();
        }

        [Key]
        public int Id { get; set; }
        [Display(Name = "Person")]
        public int CommonPersonId { get; set; }
        [Display(Name = "Movement Class")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        public int? ConfidentialityTypeId { get; set; }
        [Display(Name = "Distinguishable Marks")]
        [DataType(DataType.MultilineText)]
        public string DistinguishableMarks { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }

        [Display(Name = "Confidentiality Type")]
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        [Display(Name = "Movement Class")]
        public virtual MovementClass MovementClass { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        [Display(Name = "Person")]
        public virtual CommonPerson CommonPerson { get; set; }

        public virtual ICollection<PersonComment> PersonComments { get; set; }
        public virtual ICollection<PersonContactRel> PersonContactRels { get; set; }
        public virtual ICollection<PersonScreenName> PersonScreenNames { get; set; }
        public virtual ICollection<ChapterPersonRel> ChapterPersonRels { get; set; }
        public virtual ICollection<OrganizationPersonRel> OrganizationPersonRels { get; set; }
        public virtual ICollection<PersonEventRel> PersonEventRels { get; set; }
        public virtual ICollection<PersonPersonRel> PersonPersonRels { get; set; }
        public virtual ICollection<PersonMediaImageRel> PersonMediaImageRels { get; set; }
        public virtual ICollection<PersonMediaAudioVideoRel> PersonMediaAudioVideoRels { get; set; }
        public virtual ICollection<PersonMediaCorrespondenceRel> PersonMediaCorrespondenceRels { get; set; }
        public virtual ICollection<PersonMediaPublishedRel> PersonMediaPublishedRels { get; set; }
        public virtual ICollection<PersonPersonRel> PersonPersonRels2 { get; set; }
        public virtual ICollection<PersonVehicleRel> PersonVehicleRels { get; set; }
        public virtual ICollection<PersonMediaWebsiteEGroupRel> PersonMediaWebsiteEGroupRels { get; set; }
    }
}
