using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;
using splc.domain.Validators;

namespace splc.domain.Models
{
    public partial class PersonEventRel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Person")]
        [Required(ErrorMessage = "Person is required.")]
        public int PersonId { get; set; }
        [Display(Name = "Event")]
        [Required(ErrorMessage = "Event is required.")]
        public int EventId { get; set; }
        //[LessThan("DateEnd", PassOnNull = true, ErrorMessage = "Date Start must be before Date End")]
        [Display(Name = "Start Date")]
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
        public virtual Event Event { get; set; }
        [Display(Name = "Person")]
        public virtual BeholderPerson BeholderPerson { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
        [Display(Name = "Relationship Type")]
        public virtual RelationshipType RelationshipType { get; set; }
    }
}
