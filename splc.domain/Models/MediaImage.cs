using splc.domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaImage : StateInfo
    {
        public MediaImage()
        {
            //this.ChapterMediaImageRels = new List<ChapterMediaImageRel>();
            //this.EventMediaImageRels = new List<EventMediaImageRel>();
            //this.OrganizationMediaImageRels = new List<OrganizationMediaImageRel>();
            //this.PersonMediaImageRels = new List<PersonMediaImageRel>();
            //this.ContactMediaImageRels = new List<ContactMediaImageRel>();
            //this.MediaCorrespondenceMediaImageRels = new List<MediaCorrespondenceMediaImageRel>();
            //this.MediaImageComments = new List<MediaImageComment>();
            //this.MediaImageMediaAudioVideoRels = new List<MediaImageMediaAudioVideoRel>();
            //this.MediaImageMediaImageRels = new List<MediaImageMediaImageRel>();
            //this.MediaImageMediaImageRels1 = new List<MediaImageMediaImageRel>();
            //this.MediaImageMediaWebsiteEGroupRels = new List<MediaImageMediaWebsiteEGroupRel>();
            //this.MediaImageSubscriptionRels = new List<MediaImageSubscriptionRel>();
            //this.MediaImageVehicleRels = new List<MediaImageVehicleRel>();
            //this.MediaPublishedMediaImageRels = new List<MediaPublishedMediaImageRel>();
        }

        public int Id { get; set; }
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }
        [Display(Name = "Image Type")]
        public int? ImageTypeId { get; set; }
        [Display(Name = "Image Title")]
        public string ImageTitle { get; set; }
        [Display(Name = "Photographer/Artist")]
        [RegularExpression(@"^([a-zA-Z]+\s)*[a-zA-Z]+$", ErrorMessage = "Enter a valid Photgrapher/Artist. Letter characters only")]
        public string PhotographerArtist { get; set; }
        [Display(Name = "Date Published")]
        ////[GreaterThan("DateTaken", PassOnNull = true, ErrorMessage = "Date Published must be after Date Taken.")]
        [FutureDate]
        public DateTime? DatePublished { get; set; }
        [Display(Name = "Roll/Frame Number")]
        //[Range(0, int.MaxValue, ErrorMessage = "Enter valid number.")]
        public string RollFrameNumber { get; set; }
        [Display(Name = "News Source")]
        public int? NewsSourceId { get; set; }
        [Display(Name = "Contact/Owner")]
        public string ContactOwner { get; set; }
        [Display(Name = "Movement Class")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        [Required(ErrorMessage = "Select a valid Confidentiality Type")]
        public int ConfidentialityTypeId { get; set; }
        [Display(Name = "Renewal Date")]
        public DateTime? DateRenewalPermission { get; set; }
        [Display(Name = "Renewal Permission Type")]
        public int? RenewalPermissionTypeId { get; set; }
        [Display(Name = "Renewal Permission")]
        public string RenewalPermission { get; set; }
        [DataType(DataType.MultilineText)]
        public string Summary { get; set; }
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "City contains invalid characters.")]
        public string City { get; set; }
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "County contains invalid characters.")]
        public string County { get; set; }
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Display(Name = "Batch Sort Order")]
        public int? BatchSortOrder { get; set; }
        [Display(Name = "File Name")]
        public string ImageFileName { get; set; }
        [Display(Name = "Date Taken")]
        [FutureDate]
        public DateTime? DateTaken { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }
        [Display(Name = "Image")]
        public int? ImageId { get; set; }
        [Display(Name = "Catalog Id")]
        public string CatalogId { get; set; }



        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual MediaType MediaType { get; set; }
        public virtual Image Image { get; set; }
        public virtual ImageType ImageType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        public virtual NewsSource NewsSource { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        public virtual RenewalPermmisionType RenewalPermmisionType { get; set; }
        public virtual State State { get; set; }

        public virtual ICollection<ChapterMediaImageRel> ChapterMediaImageRels { get; set; }
        public virtual ICollection<EventMediaImageRel> EventMediaImageRels { get; set; }
        public virtual ICollection<ContactMediaImageRel> ContactMediaImageRels { get; set; }
        public virtual ICollection<MediaCorrespondenceMediaImageRel> MediaCorrespondenceMediaImageRels { get; set; }
        public virtual ICollection<MediaImageComment> MediaImageComments { get; set; }
        //public virtual ICollection<MediaImageMediaAudioVideoRel> MediaImageMediaAudioVideoRels { get; set; }
        public virtual ICollection<MediaImageMediaImageRel> MediaImageMediaImageRels { get; set; }
        public virtual ICollection<MediaImageMediaImageRel> MediaImageMediaImageRels2 { get; set; }
        public virtual ICollection<MediaImageMediaWebsiteEGroupRel> MediaImageMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<MediaImageSubscriptionRel> MediaImageSubscriptionRels { get; set; }
        public virtual ICollection<MediaPublishedMediaImageRel> MediaPublishedMediaImageRels { get; set; }
        public virtual ICollection<MediaImageVehicleRel> MediaImageVehicleRels { get; set; }
        public virtual ICollection<MediaImageMediaAudioVideoRel> MediaImageMediaAudioVideoRels { get; set; }
        public virtual ICollection<OrganizationMediaImageRel> OrganizationMediaImageRels { get; set; }
        public virtual ICollection<PersonMediaImageRel> PersonMediaImageRels { get; set; }
    }
}
