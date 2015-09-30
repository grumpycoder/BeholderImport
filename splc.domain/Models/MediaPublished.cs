using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foolproof;
using splc.domain.Validators;

namespace splc.domain.Models
{
    public partial class MediaPublished : StateInfo
    {
        public MediaPublished()
        {
            //this.ChapterMediaPublishedRels = new List<ChapterMediaPublishedRel>();
            //this.ContactMediaPublishedRels = new List<ContactMediaPublishedRel>();
            //this.MediaPublishedComments = new List<MediaPublishedComment>();
            //this.MediaPublishedEventRels = new List<MediaPublishedEventRel>();
            //this.MediaPublishedMediaAudioVideoRels = new List<MediaPublishedMediaAudioVideoRel>();
            //this.MediaPublishedMediaCorrespondenceRels = new List<MediaPublishedMediaCorrespondenceRel>();
            //this.MediaPublishedMediaImageRels = new List<MediaPublishedMediaImageRel>();
            //this.MediaPublishedMediaPublishedRels = new List<MediaPublishedMediaPublishedRel>();
            //this.MediaPublishedMediaPublishedRels2 = new List<MediaPublishedMediaPublishedRel>();
            //this.MediaPublishedMediaWebsiteEGroupRels = new List<MediaPublishedMediaWebsiteEGroupRel>();
            //this.MediaPublishedSubscriptionRels = new List<MediaPublishedSubscriptionRel>();
            //this.MediaPublishedVehicleRels = new List<MediaPublishedVehicleRel>();
            //this.OrganizationMediaPublishedRels = new List<OrganizationMediaPublishedRel>();
            //this.PersonMediaPublishedRels = new List<PersonMediaPublishedRel>();
        }

        public int Id { get; set; }
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }
        [Display(Name = "Published Type")]
        public int? PublishedTypeId { get; set; }
        [Display(Name = "Library Category Type")]
        public int? LibraryCategoryTypeId { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Date Published")]
        [FutureDate]
        public DateTime? DatePublished { get; set; }
        [Display(Name = "Date Received")]
        [FutureDate]
        ////[GreaterThan("DatePublished", ErrorMessage = "Date Received cannot be greater than Date Published.")]
        public DateTime? DateReceived { get; set; }
        [Display(Name = "Author")]
        public string Author { get; set; }
        [Display(Name = "News Source")]
        public int? NewsSourceId { get; set; }
        [Display(Name = "Movement Class")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        [Required(ErrorMessage = "Select a valid Confidentiality Type")]
        public int ConfidentialityTypeId { get; set; }
        [Display(Name = "Date Renewal Permission")]
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
        public int? MediaPublishedContextId { get; set; }
        [Display(Name = "Catalog Id")]
        public string CatalogId { get; set; }

        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual LibraryCategoryType LibraryCategoryType { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        public virtual NewsSource NewsSource { get; set; }
        public virtual PublishedType PublishedType { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        public virtual RenewalPermmisionType RenewalPermmisionType { get; set; }
        public virtual State State { get; set; }
        //public virtual MediaPublishedContext MediaPublishedContext { get; set; }
        //public virtual MediaPublishedContext_Index MediaPublishedContext_Index { get; set; }

        public virtual ICollection<ChapterMediaPublishedRel> ChapterMediaPublishedRels { get; set; }
        public virtual ICollection<MediaPublishedComment> MediaPublishedComments { get; set; }
        public virtual ICollection<MediaPublishedEventRel> MediaPublishedEventRels { get; set; }
        public virtual ICollection<MediaPublishedMediaAudioVideoRel> MediaPublishedMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaPublishedMediaCorrespondenceRel> MediaPublishedMediaCorrespondenceRels { get; set; }
        public virtual ICollection<MediaPublishedMediaImageRel> MediaPublishedMediaImageRels { get; set; }
        public virtual ICollection<MediaPublishedMediaPublishedRel> MediaPublishedMediaPublishedRels { get; set; }
        public virtual ICollection<MediaPublishedMediaPublishedRel> MediaPublishedMediaPublishedRels2 { get; set; }
        public virtual ICollection<MediaPublishedMediaWebsiteEGroupRel> MediaPublishedMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaPublishedSubscriptionRel> MediaPublishedSubscriptionRels { get; set; }
        public virtual ICollection<MediaPublishedVehicleRel> MediaPublishedVehicleRels { get; set; }
        public virtual ICollection<OrganizationMediaPublishedRel> OrganizationMediaPublishedRels { get; set; }
        public virtual ICollection<PersonMediaPublishedRel> PersonMediaPublishedRels { get; set; }
        public virtual ICollection<MediaPublishedContext> MediaPublishedContexts { get; set; }
        public virtual ICollection<MediaPublishedContext_Index> MediaPublishedContext_Indexes { get; set; }
    }
}
