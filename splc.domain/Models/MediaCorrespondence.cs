using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using splc.domain.Validators;

namespace splc.domain.Models
{
    public partial class MediaCorrespondence : StateInfo
    {
        public MediaCorrespondence()
        {
            //this.ChapterMediaCorrespondenceRels = new List<ChapterMediaCorrespondenceRel>();
            //this.ContactMediaCorrespondenceRels = new List<ContactMediaCorrespondenceRel>();
            //this.MediaCorrespondenceComments = new List<MediaCorrespondenceComment>();
            //this.MediaCorrespondenceEventRels = new List<MediaCorrespondenceEventRel>();
            //this.MediaCorrespondenceMediaAudioVideoRels = new List<MediaCorrespondenceMediaAudioVideoRel>();
            //this.MediaCorrespondenceMediaCorrespondenceRels = new List<MediaCorrespondenceMediaCorrespondenceRel>();
            //this.MediaCorrespondenceMediaCorrespondenceRels1 = new List<MediaCorrespondenceMediaCorrespondenceRel>();
            //this.MediaCorrespondenceMediaImageRels = new List<MediaCorrespondenceMediaImageRel>();
            //this.MediaCorrespondenceMediaWebsiteEGroupRels = new List<MediaCorrespondenceMediaWebsiteEGroupRel>();
            //this.MediaCorrespondenceNewsSourceRels = new List<MediaCorrespondenceNewsSourceRel>();
            //this.MediaCorrespondenceSubscriptionRels = new List<MediaCorrespondenceSubscriptionRel>();
            //this.MediaCorrespondenceVehicleRels = new List<MediaCorrespondenceVehicleRel>();
            //this.MediaPublishedMediaCorrespondenceRels = new List<MediaPublishedMediaCorrespondenceRel>();
            //this.OrganizationMediaCorrespondenceRels = new List<OrganizationMediaCorrespondenceRel>();
            //this.PersonMediaCorrespondenceRels = new List<PersonMediaCorrespondenceRel>();
        }

        public int Id { get; set; }
        [Display(Name = "Media Type")]
        public int? MediaTypeId { get; set; }
        [Display(Name = "Correspondence Type")]
        public int? CorrespondenceTypeId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string CorrespondenceName { get; set; }
        [Display(Name = "Date Received")]
        [FutureDate]
        public DateTime? DateReceived { get; set; }
        [Display(Name = "Movement Class")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        [Required(ErrorMessage = "Select a valid Confidentiality Type")]
        public int ConfidentialityTypeId { get; set; }
        [Display(Name = "To Name")]
        public string ToName { get; set; }
        [Display(Name = "From Name")]
        public string FromName { get; set; }
        [Display(Name = "Renewal Permission Date")]
        public DateTime? DateRenewalPermission { get; set; }
        [Display(Name = "Renewal Permission Type")]
        public int? RenewalPermissionTypeId { get; set; }
        [Display(Name = "Renewal Permission")]
        public string RenewalPermission { get; set; }
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
        [RegularExpression(@"^([a-zA-Z]+\s)*[a-zA-Z]+$", ErrorMessage = "Enter a valid City. Letter characters only")]
        public string City { get; set; }
        [RegularExpression(@"^([a-zA-Z]+\s)*[a-zA-Z]+$", ErrorMessage = "Enter a valid County. Letter characters only")]
        public string County { get; set; }
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }
        public int? MediaCorrespondenceContextId { get; set; }
        [Display(Name = "Catalog Id")]
        public string CatalogId { get; set; }

        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual CorrespondenceType CorrespondenceType { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        public virtual RenewalPermmisionType RenewalPermmisionType { get; set; }
        public virtual State State { get; set; }
        //public virtual MediaCorrespondenceContext MediaCorrespondenceContext { get; set; }
        //public virtual MediaCorrespondenceContext_Index MediaCorrespondenceContext_Index { get; set; }
        public virtual ICollection<MediaCorrespondenceContext> MediaCorrespondenceContexts { get; set; }
        public virtual ICollection<MediaCorrespondenceContext_Index> MediaCorrespondenceContext_Indexes { get; set; }

        public virtual ICollection<ContactMediaCorrespondenceRel> ContactMediaCorrespondenceRels { get; set; }
        public virtual ICollection<ChapterMediaCorrespondenceRel> ChapterMediaCorrespondenceRels { get; set; }
        public virtual ICollection<MediaCorrespondenceComment> MediaCorrespondenceComments { get; set; }
        public virtual ICollection<MediaCorrespondenceEventRel> MediaCorrespondenceEventRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaAudioVideoRel> MediaCorrespondenceMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaCorrespondenceRel> MediaCorrespondenceMediaCorrespondenceRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaCorrespondenceRel> MediaCorrespondenceMediaCorrespondenceRels2 { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaImageRel> MediaCorrespondenceMediaImageRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaWebsiteEGroupRel> MediaCorrespondenceMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaCorrespondenceSubscriptionRel> MediaCorrespondenceSubscriptionRels { get; set; }
        public virtual ICollection<MediaCorrespondenceVehicleRel> MediaCorrespondenceVehicleRels { get; set; }
        public virtual ICollection<OrganizationMediaCorrespondenceRel> OrganizationMediaCorrespondenceRels { get; set; }
        public virtual ICollection<PersonMediaCorrespondenceRel> PersonMediaCorrespondenceRels { get; set; }
        public virtual ICollection<MediaPublishedMediaCorrespondenceRel> MediaPublishedMediaCorrespondenceRels { get; set; }
    }
}
