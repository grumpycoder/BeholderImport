using System.Web.Mvc;
using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ContactInfoPersonRel : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Person")]
        public int PersonId { get; set; }
        [Display(Name = "Contact")]
        public int ContactInfoId { get; set; }
        [Display(Name = "Contact Type")]
        public int ContactInfoTypeId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("PersonHasPrimaryContactInfo", "Validation", AdditionalFields = "Id, PersonId", ErrorMessage = "Person already has primary contact.", HttpMethod = "POST")]
        public int? PrimaryStatusId { get; set; }

        [Display(Name = "Contact")]
        public virtual ContactInfo ContactInfo { get; set; }
        [Display(Name = "Contact Type")]
        public virtual ContactInfoType ContactInfoType { get; set; }
        [Display(Name = "Person")]
        public virtual CommonPerson CommonPerson { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
    }
}
