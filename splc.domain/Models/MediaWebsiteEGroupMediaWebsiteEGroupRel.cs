using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using splc.domain.Validators;

namespace splc.domain.Models
{
    public partial class MediaWebsiteEGroupMediaWebsiteEGroupRel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Website EGroup")]
        public int MediaWebsiteEGroupId { get; set; }
        [Display(Name = "Website EGroup")]
        [NotEqualTo("MediaWebsiteEGroupId", PassOnNull = true, ErrorMessage = "Unable to add relationship to itself")]
        public int MediaWebsiteEGroup2Id { get; set; }
        [Display(Name = "Start Date")]
        //[LessThan("DateEnd", PassOnNull = true, ErrorMessage = "Date Start must be before Date End")]
        [FutureDate]
        public DateTime? DateStart { get; set; }
        [Display(Name = "End Date")]
        [FutureDate]
        public DateTime? DateEnd { get; set; }
        [Display(Name = "Relationship Type")]
        public int RelationshipTypeId { get; set; }
        [Display(Name = "Approval Status")]
        public int? ApprovalStatusId { get; set; }
        [Display(Name = "Primary Status")]
        public int? PrimaryStatusId { get; set; }

        [Display(Name = "Approval Status")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        [Display(Name = "Website EGroup")]
        public virtual MediaWebsiteEGroup MediaWebsiteEGroup { get; set; }
        [Display(Name = "Website EGroup")]
        public virtual MediaWebsiteEGroup MediaWebsiteEGroup2 { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
        [Display(Name = "Relationship Type")]
        public virtual RelationshipType RelationshipType { get; set; }
    }
}
