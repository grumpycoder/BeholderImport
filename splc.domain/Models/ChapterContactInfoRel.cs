using System.Web.Mvc;
using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ChapterContactInfoRel : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public int ContactInfoId { get; set; }
        [Display(Name = "Contact Type")]
        [Required(ErrorMessage = "Contact Type is required.")]
        public int ContactInfoTypeId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("ChapterHasPrimaryContactInfo", "Validation", AdditionalFields = "Id, ChapterId", ErrorMessage = "Chapter already has primary contact.", HttpMethod = "POST")]
        public int? PrimaryStatusId { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }
        [Display(Name = "Contact Type")]
        public virtual ContactInfoType ContactInfoType { get; set; }
        public virtual Chapter Chapter { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
    }
}
