using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;
using splc.domain.Validators;

namespace splc.domain.Models
{
    public partial class EventEventRel
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        [NotEqualTo("EventId", PassOnNull = true, ErrorMessage = "Unable to add relationship to itself")]
        public int Event2Id { get; set; }
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
        [Display(Name = "Event")]
        public virtual Event Event { get; set; }
        [Display(Name = "Event")]
        public virtual Event Event2 { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
        [Display(Name = "Relationship Type")]
        public virtual RelationshipType RelationshipType { get; set; }
    }
}
