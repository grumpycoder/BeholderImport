using splc.domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaWebsiteEGroup : StateInfo
    {
        public MediaWebsiteEGroup()
        {
            //this.ChapterMediaWebsiteEGroupRels = new List<ChapterMediaWebsiteEGroupRel>();
            //this.ContactMediaWebsiteEGroupRels = new List<ContactMediaWebsiteEGroupRel>();
            //this.EventMediaWebsiteEGroupRels = new List<EventMediaWebsiteEGroupRel>();
            //this.MediaCorrespondenceMediaWebsiteEGroupRels = new List<MediaCorrespondenceMediaWebsiteEGroupRel>();
            //this.MediaImageMediaWebsiteEGroupRels = new List<MediaImageMediaWebsiteEGroupRel>();
            //this.MediaPublishedMediaWebsiteEGroupRels = new List<MediaPublishedMediaWebsiteEGroupRel>();
            //this.MediaWebsiteEGroupComments = new List<MediaWebsiteEGroupComment>();
            //this.MediaWebsiteEGroupMediaAudioVideoRels = new List<MediaWebsiteEGroupMediaAudioVideoRel>();
            //this.MediaWebsiteEGroupMediaWebsiteEGroupRels = new List<MediaWebsiteEGroupMediaWebsiteEGroupRel>();
            //this.MediaWebsiteEGroupMediaWebsiteEGroupRels1 = new List<MediaWebsiteEGroupMediaWebsiteEGroupRel>();
            //this.MediaWebsiteEGroupSubscriptionRels = new List<MediaWebsiteEGroupSubscriptionRel>();
            //this.MediaWebsiteEGroupVehicleRels = new List<MediaWebsiteEGroupVehicleRel>();
            //this.OrganizationMediaWebsiteEGroupRels = new List<OrganizationMediaWebsiteEGroupRel>();
            //this.PersonMediaWebsiteEGroupRels = new List<PersonMediaWebsiteEGroupRel>();
        }

        public int Id { get; set; }
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }
        [Display(Name = "Website EGroup Type")]
        public int? WebsiteEGroupTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string URL { get; set; }
        [Display(Name = "Date Discovered")]
        [FutureDate]
        //[GreaterThan("DatePublished", PassOnNull = true, ErrorMessage = "Date Discovered must be after the Date Published.")]
        public DateTime? DateDiscovered { get; set; }
        [Display(Name = "Date Published")]
        [FutureDate]
        //[LessThan("DateOffline", PassOnNull = true, ErrorMessage = "Date Published must be less than Date Offline.")]
        public DateTime? DatePublished { get; set; }
        [Display(Name = "Date Offline")]
        //[GreaterThan("DateDiscovered", PassOnNull = true, ErrorMessage = "Date Offline must be after the Date Discovered.")]
        [FutureDate]
        public DateTime? DateOffline { get; set; }
        [Display(Name = "IPAddress")]
        [RegularExpression(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", ErrorMessage = "Enter a valid IP Address.")]
        public string IPAddress { get; set; }
        [Display(Name = "News Source")]
        public int? NewsSourceId { get; set; }
        [Display(Name = "Movement Class")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        [Required(ErrorMessage = "Select a valid Confidentiality Type")]
        public int ConfidentialityTypeId { get; set; }
        [Display(Name = "Active Year")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        public int? ActiveYear { get; set; }
        [Display(Name = "Active Status")]
        public int? ActiveStatusId { get; set; }
        [Display(Name = "Reported")]
        public bool? IsReported { get; set; }
        [Display(Name = "Approval Status")]
        public int? ApprovalStatusId { get; set; }
        [Display(Name = "WhoIs Info")]
        public string WhoIsInfo { get; set; }
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
        public int? MediaWebsiteEGroupContextId { get; set; }

        public virtual ActiveStatus ActiveStatus { get; set; }
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        public virtual NewsSource NewsSource { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        public virtual State State { get; set; }
        public virtual WebsiteGroupType WebsiteGroupType { get; set; }
        //public virtual MediaWebsiteEGroupContext MediaWebsiteEGroupContext { get; set; }
        //public virtual MediaWebsiteEGroupContext_Index MediaWebsiteEGroupContext_Index { get; set; }

        public virtual ICollection<ChapterMediaWebsiteEGroupRel> ChapterMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<EventMediaWebsiteEGroupRel> EventMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaWebsiteEGroupRel> MediaCorrespondenceMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaImageMediaWebsiteEGroupRel> MediaImageMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaPublishedMediaWebsiteEGroupRel> MediaPublishedMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupComment> MediaWebsiteEGroupComments { get; set; }
        public virtual ICollection<MediaWebsiteEGroupMediaAudioVideoRel> MediaWebsiteEGroupMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupMediaWebsiteEGroupRel> MediaWebsiteEGroupMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupMediaWebsiteEGroupRel> MediaWebsiteEGroupMediaWebsiteEGroupRels2 { get; set; }
        public virtual ICollection<MediaWebsiteEGroupSubscriptionRel> MediaWebsiteEGroupSubscriptionRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupVehicleRel> MediaWebsiteEGroupVehicleRels { get; set; }
        public virtual ICollection<OrganizationMediaWebsiteEGroupRel> OrganizationMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<PersonMediaWebsiteEGroupRel> PersonMediaWebsiteEGroupRels { get; set; }

        public virtual ICollection<MediaWebsiteEGroupContext> MediaWebsiteEGroupContexts { get; set; }
        public virtual ICollection<MediaWebsiteEGroupContext_Index> MediaWebsiteEGroupContext_Indexes { get; set; }

    }
}
