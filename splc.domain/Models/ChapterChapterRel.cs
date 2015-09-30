
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using splc.domain.Validators;

namespace splc.domain.Models
{
    public partial class ChapterChapterRel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Chapter1")]
        public int ChapterId { get; set; }
        [Display(Name = "Chapter2")]
//        [NotEqualTo("ChapterId", PassOnNull = true, ErrorMessage = "Unable to add relationship to itself")]
        public int Chapter2Id { get; set; }
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
        public virtual Chapter Chapter { get; set; }
        //public virtual Chapter Chapter1 { get; set; }
        [Display(Name = "Chapter")]
        public virtual Chapter Chapter2 { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
        [Display(Name = "Relationship Type")]
        public virtual RelationshipType RelationshipType { get; set; }

    }
}
