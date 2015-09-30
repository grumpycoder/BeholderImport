using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaAudioVideo : StateInfo
    {
        public MediaAudioVideo()
        {
            //this.ChapterMediaAudioVideoRels = new List<ChapterMediaAudioVideoRel>();
            //this.ContactMediaAudioVideoRels = new List<ContactMediaAudioVideoRel>();
            //this.EventMediaAudioVideoRels = new List<EventMediaAudioVideoRel>();
            //this.MediaAudioVideoComments = new List<MediaAudioVideoComment>();
            //this.MediaAudioVideoVehicleRels = new List<MediaAudioVideoVehicleRel>();
            //this.MediaCorrespondenceMediaAudioVideoRels = new List<MediaCorrespondenceMediaAudioVideoRel>();
            //this.MediaImageMediaAudioVideoRels = new List<MediaImageMediaAudioVideoRel>();
            //this.MediaPublishedMediaAudioVideoRels = new List<MediaPublishedMediaAudioVideoRel>();
            //this.MediaWebsiteEGroupMediaAudioVideoRels = new List<MediaWebsiteEGroupMediaAudioVideoRel>();
            //this.OrganizationMediaAudioVideoRels = new List<OrganizationMediaAudioVideoRel>();
        }

        public int Id { get; set; }
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }
        [Display(Name = "Audio/Video Type")]
        public int AudioVideoTypeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "Date Received/Recorded")]
        public DateTime? DateReceivedRecorded { get; set; }
        [Display(Name = "Date Aired")]
        public DateTime? DateAired { get; set; }
        [Display(Name = "Speaker/Commentator")]
        public string SpeakerCommentator { get; set; }
        [Display(Name = "Media Length")]
        //[DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [RegularExpression(@"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Length should be hh:mm")]
        public string MediaLength { get; set; }
        [Display(Name = "News Source")]
        public int? NewsSourceId { get; set; }
        [Display(Name = "Movement Class")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        public int? ConfidentialityTypeId { get; set; }
        [Display(Name = "Date Renewal")]
        public DateTime? DateRenewalPermission { get; set; }
        [Display(Name = "Renewal Permission Type")]
        public int? RenewalPermissionTypeId { get; set; }
        [Display(Name = "Renewal Permission")]
        public string RenewalPermission { get; set; }
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
        [Display(Name = "Catalog Id")]
        public string CatalogId { get; set; }

        public virtual AudioVideoType AudioVideoType { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        public virtual NewsSource NewsSource { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        public virtual RenewalPermmisionType RenewalPermmisionType { get; set; }
        public virtual State State { get; set; }
        
        public virtual ICollection<MediaAudioVideoComment> MediaAudioVideoComments { get; set; }
        public virtual ICollection<ChapterMediaAudioVideoRel> ChapterMediaAudioVideoRels { get; set; }
        public virtual ICollection<OrganizationMediaAudioVideoRel> OrganizationMediaAudioVideoRels { get; set; }
        public virtual ICollection<PersonMediaAudioVideoRel> PersonMediaAudioVideoRels { get; set; }
        public virtual ICollection<EventMediaAudioVideoRel> EventMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaAudioVideoVehicleRel> MediaAudioVideoVehicleRels { get; set; }
        public virtual ICollection<MediaImageMediaAudioVideoRel> MediaImageMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaAudioVideoRel> MediaCorrespondenceMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaPublishedMediaAudioVideoRel> MediaPublishedMediaAudioVideoRels { get; set; }
        //public virtual ICollection<ContactMediaAudioVideoRel> ContactMediaAudioVideoRels { get; set; }
        //public virtual ICollection<MediaImageMediaAudioVideoRel> MediaImageMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupMediaAudioVideoRel> MediaWebsiteEGroupMediaAudioVideoRels { get; set; }
        //public virtual ICollection<OrganizationMediaAudioVideoRel> OrganizationMediaAudioVideoRels { get; set; }

    }
}
