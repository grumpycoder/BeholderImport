
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Foolproof;

namespace splc.domain.Models
{
    public partial class AddressPersonRel : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Person")]
        public int PersonId { get; set; }
        public int AddressId { get; set; }
        [Display(Name = "Type")]
        public int? AddressTypeId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("PersonHasPrimaryAddress", "Validation", AdditionalFields = "Id, PersonId", ErrorMessage = "Person already has primary address.", HttpMethod = "POST") ]
        public int PrimaryStatusId { get; set; }

        public virtual Address Address { get; set; }
        [Display(Name = "Address Type")]
        public virtual AddressType AddressType { get; set; }
        public virtual CommonPerson CommonPerson { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
    }
}
