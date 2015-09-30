using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace splc.domain.Models
{
    public partial class Organization : StateInfo
    {
        public Organization()
        {
            //this.OrganizationPersonRels = new List<OrganizationPersonRel>();
            //this.AliasOrganizationRels = new List<AliasOrganizationRel>();
            //this.ChapterOrganizationRels = new List<ChapterOrganizationRel>();
            //this.OrganizationMediaImageRels = new List<OrganizationMediaImageRel>();
            //this.OrganizationComments = new List<OrganizationComment>();

        }

        public int Id { get; set; }
        [Display(Name = "Organization Type")]
        public int OrganizationTypeId { get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage = "Organization Name is required.")]
        public string OrganizationName { get; set; }
        [Display(Name="Description")]
        [DataType(DataType.MultilineText)]
        public string OrganizationDesc { get; set; }
        [Display(Name = "Approval Status")]
        public int ApprovalStatusId { get; set; }
        [Display(Name = "Active Status")]
        public int ActiveStatusId { get; set; }
        [Display(Name = "Active Year")]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit Year")]
        public int ActiveYear { get; set; }
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

        public virtual ActiveStatus ActiveStatus { get; set; }
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual MovementClass MovementClass { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }
        public virtual OrganizationType OrganizationType { get; set; }

        public virtual ICollection<AliasOrganizationRel> AliasOrganizationRels { get; set; }
        public virtual ICollection<OrganizationPersonRel> OrganizationPersonRels { get; set; }
        public virtual ICollection<ChapterOrganizationRel> ChapterOrganizationRels { get; set; }
        public virtual ICollection<OrganizationMediaImageRel> OrganizationMediaImageRels { get; set; }
        public virtual ICollection<OrganizationMediaAudioVideoRel> OrganizationMediaAudioVideoRels { get; set; }
        public virtual ICollection<OrganizationEventRel> OrganizationEventRels { get; set; }
        public virtual ICollection<OrganizationVehicleRel> OrganizationVehicleRels { get; set; }
        public virtual ICollection<OrganizationOrganizationRel> OrganizationOrganizationRels { get; set; }
        public virtual ICollection<OrganizationOrganizationRel> OrganizationOrganizationRels2 { get; set; }
        public virtual ICollection<OrganizationMediaCorrespondenceRel> OrganizationMediaCorrespondenceRels { get; set; }
        public virtual ICollection<OrganizationMediaPublishedRel> OrganizationMediaPublishedRels { get; set; }
        public virtual ICollection<OrganizationSubscriptionRel> OrganizationSubscriptionRels { get; set; }
        public virtual ICollection<OrganizationStatusHistory> OrganizationStatusHistories { get; set; }
        public virtual ICollection<OrganizationMediaWebsiteEGroupRel> OrganizationMediaWebsiteEGroupRels { get; set; }
        public virtual ICollection<OrganizationComment> OrganizationComments { get; set; }

    }
}
