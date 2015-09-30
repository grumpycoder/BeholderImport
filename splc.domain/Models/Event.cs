using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Event : StateInfo
    {
        public Event()
        {
            //this.AddressEventRels = new List<AddressEventRel>();
            //this.ContactEventRels = new List<ContactEventRel>();
            //this.EventComments = new List<EventComment>();
            //this.EventEventRels = new List<EventEventRel>();
            //this.EventEventRels1 = new List<EventEventRel>();
            //this.EventMediaAudioVideoRels = new List<EventMediaAudioVideoRel>();
            //this.EventMediaImageRels = new List<EventMediaImageRel>();
            //this.EventMediaWebsiteEGroupRels = new List<EventMediaWebsiteEGroupRel>();
            //this.EventNewsSourceRels = new List<EventNewsSourceRel>();
            //this.EventStatusHistories = new List<EventStatusHistory>();
            //this.EventSubscriptionRels = new List<EventSubscriptionRel>();
            //this.EventVehicleRels = new List<EventVehicleRel>();
            //this.MediaCorrespondenceEventRels = new List<MediaCorrespondenceEventRel>();
            //this.MediaPublishedEventRels = new List<MediaPublishedEventRel>();
            //this.OrganizationEventRels = new List<OrganizationEventRel>();
            //this.PersonEventRels = new List<PersonEventRel>();
            //EventEventTypeRels = new Collection<EventEventTypeRel>();
        }

        public int Id { get; set; }
        [Display(Name = "Event Name")]
        [Required]
        [MaxLength(100, ErrorMessage = "Event name limited to 100 characters.")]
        public string EventName { get; set; }
        [Display(Name = "Event Date")]
        public DateTime? EventDate { get; set; }
        [Display(Name = "Event Documentation Type")]
        public int? EventDocumentationTypeId { get; set; }
        [Display(Name = "Approval Status")]
        public int ApprovalStatusId { get; set; }
        [Display(Name = "Active Status")]
        public int ActiveStatusId { get; set; }
        [Display(Name = "Active Year")]
        //TODO: Event regular expression errors on modelstate validation on relationship create edit screens. 
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        public int ActiveYear { get; set; }
        [Display(Name = "Report Status")]
        public bool ReportStatusFlag { get; set; }
        [Display(Name = "Movement Class")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        public int? ConfidentialityTypeId { get; set; }
        public string Religion { get; set; }
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
        [Display(Name = "Web Incident Type")]
        public int? WebIncidentTypeId { get; set; }
        [Display(Name = "News Source")]
        public int? NewsSourceId { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }

        public virtual ActiveStatus ActiveStatus { get; set; }
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual EventDocumentationType EventDocumentationType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        public virtual WebIncidentType WebIncidentType { get; set; }
        public virtual NewsSource NewsSource { get; set; }

        public virtual ICollection<EventEventTypeRel> EventEventTypeRels { get; set; }
        public virtual ICollection<AddressEventRel> AddressEventRels { get; set; }
        public virtual ICollection<EventEventRel> EventEventRels { get; set; }
        public virtual ICollection<EventEventRel> EventEventRels2 { get; set; }
        public virtual ICollection<MediaCorrespondenceEventRel> MediaCorrespondenceEventRels { get; set; }
        public virtual ICollection<EventComment> EventComments { get; set; }
        public virtual ICollection<PersonEventRel> PersonEventRels { get; set; }
        public virtual ICollection<OrganizationEventRel> OrganizationEventRels { get; set; }
        public virtual ICollection<ChapterEventRel> ChapterEventRels { get; set; }
        public virtual ICollection<EventMediaImageRel> EventMediaImageRels { get; set; }
        public virtual ICollection<EventMediaAudioVideoRel> EventMediaAudioVideoRels { get; set; }
        public virtual ICollection<EventVehicleRel> EventVehicleRels { get; set; }
        public virtual ICollection<MediaPublishedEventRel> MediaPublishedEventRels { get; set; }
        public virtual ICollection<EventMediaWebsiteEGroupRel> EventMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<EventSubscriptionRel> EventSubscriptionRels { get; set; }
        public virtual ICollection<EventStatusHistory> EventStatusHistories { get; set; }
    }
}
