using System.Web.Mvc;
using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;
using splc.domain.Validators;

namespace splc.domain.Models
{
    public partial class ChapterPersonRel
    {
        [Key]
        public int Id { get; set; }
        [Remote("ChapterPersonAlreadyExists", "Validation", AdditionalFields = "Id, PersonId, ChapterId", ErrorMessage = "Relationship already exists.", HttpMethod = "POST")]
        [Required(ErrorMessage = "Chapter is required.")]
        public int ChapterId { get; set; }
        [Display(Name = "Person")]
        public int BeholderPersonId { get; set; }
        [Display(Name = "Start Date")]
        //[LessThan("DateEnd", PassOnNull = true, ErrorMessage = "Date Start must be before Date End")]
        [FutureDate]
        public DateTime? DateStart { get; set; }
        [Display(Name = "End Date")]
        [FutureDate]
        public DateTime? DateEnd { get; set; }
        [Display(Name = "Relationship Type")]
        [Required(ErrorMessage = "Relationship Type is required")]
        public int? RelationshipTypeId { get; set; }
        [Display(Name = "Approval Status")]
        public int? ApprovalStatusId { get; set; }
        [Display(Name = "Primary Status")]
        public int? PrimaryStatusId { get; set; }

        public virtual Chapter Chapter { get; set; }
        [Display(Name = "Person")]
        public virtual BeholderPerson BeholderPerson { get; set; }
        [Display(Name = "Relationship Type")]
        public virtual RelationshipType RelationshipType { get; set; }
        [Display(Name = "Approval Status")]
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }

    }
}
