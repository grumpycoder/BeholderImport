using System.Web.Mvc;
using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace splc.domain.Models
{
    public partial class AddressContactRel : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Contact")]
        public int ContactId { get; set; }
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        [Display(Name = "Address Type")]
        public int? AddressTypeId { get; set; }
        [Display(Name = "First Used")]
        ////[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("ContactHasPrimaryAddress", "Validation", AdditionalFields = "Id, ContactId", ErrorMessage = "Contact already has primary address.", HttpMethod = "POST")]
        public int PrimaryStatusId { get; set; }

        [Display(Name = "Address Type")]
        public virtual AddressType AddressType { get; set; }
        public virtual Address Address { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual User CreatedUser { get; set; }
        public virtual User ModifiedUser { get; set; }
        public virtual User DeletedUser { get; set; }
        public virtual PrimaryStatus PrimaryStatus { get; set; }
    }
}
