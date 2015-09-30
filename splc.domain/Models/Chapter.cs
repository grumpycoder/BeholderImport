using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace splc.domain.Models
{
    public partial class Chapter : StateInfo, IValidatableObject
    {
        public Chapter()
        {
        
        }

        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string ChapterName { get; set; }
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string ChapterDesc { get; set; }
//        [Display(Name = "Chapter Type")]
//        public int? ChapterTypeId { get; set; }
        [Display(Name = "Approval Status")]
        public int ApprovalStatusId { get; set; }
        [Display(Name = "Active Status")]
        public int? ActiveStatusId { get; set; }
        [Display(Name = "Active Year")]
        //[Range(typeof(int), "1900", "3000", ErrorMessage = "{0} can only be between {1} and {2}")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        public int? ActiveYear { get; set; }
        [Display(Name = "Report Status")]
        public bool ReportStatusFlag { get; set; }
        [Display(Name = "Formed Date")]
        //[LessThan("DisbandDate", PassOnNull = true, ErrorMessage = "Formed Date must be less than Disband Date.")]
        public DateTime? FormedDate { get; set; }
        [Display(Name = "Disband Date")]
        //[GreaterThan("FormedDate", PassOnNull = true, ErrorMessage = "Disband Date must be greater than Formed Date.")]
        public DateTime? DisbandDate { get; set; }
        [Display(Name = "Movement")]
        public int? MovementClassId { get; set; }
        [Display(Name = "Confidentiality Type")]
        public int? ConfidentialityTypeId { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }
        [Display(Name = "Headquarters")]
        public bool IsHeadquarters { get; set; }

        public virtual ActiveStatus ActiveStatus { get; set; }
        public virtual ApprovalStatus ApprovalStatus { get; set; }
//        public virtual ChapterType ChapterType { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }

        public virtual ICollection<AddressChapterRel> AddressChapterRels { get; set; }
        public virtual ICollection<AliasChapterRel> AliasChapterRels { get; set; }
        public virtual ICollection<ChapterComment> ChapterComments { get; set; }
        public virtual ICollection<ChapterContactRel> ChapterContactRels { get; set; }
        public virtual ICollection<ChapterOrganizationRel> ChapterOrganizationRels { get; set; }
        public virtual ICollection<ChapterPersonRel> ChapterPersonRels { get; set; }
        public virtual ICollection<ChapterMediaImageRel> ChapterMediaImageRels { get; set; }
        public virtual ICollection<ChapterMediaAudioVideoRel> ChapterMediaAudioVideoRels { get; set; }
        public virtual ICollection<ChapterEventRel> ChapterEventRels { get; set; }
        public virtual ICollection<ChapterVehicleRel> ChapterVehicleRels { get; set; }
        public virtual ICollection<ChapterChapterRel> ChapterChapterRels { get; set; }
        public virtual ICollection<ChapterChapterRel> ChapterChapterRels2 { get; set; }
        public virtual ICollection<ChapterContactInfoRel> ChapterContactInfoRels { get; set; }
        public virtual ICollection<ChapterMediaCorrespondenceRel> ChapterMediaCorrespondenceRels { get; set; }
        public virtual ICollection<ChapterMediaPublishedRel> ChapterMediaPublishedRels { get; set; }
        public virtual ICollection<ChapterMediaWebsiteEGroupRel> ChapterMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<ChapterSubscriptionRel> ChapterSubscriptionRels { get; set; }
        public virtual ICollection<ChapterStatusHistory> ChapterStatusHistories { get; set; }

        public Status Status { get; set; }
        public SecurityLevel SecurityLevel { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ChapterName == "Test")
            {
                yield return new ValidationResult("Test Validation.", new[] { "ChapterName" });

            }
        }

    }

    [Flags]
    public enum Status
    {
        Active = 1,
        InActive = 2,
        Review = 4,
        Deleted = 8,
        Approved = 16,
        Pending = 32,
        Disapproved = 64,
        New = 128
    }
}
