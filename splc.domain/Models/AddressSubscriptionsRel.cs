using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace splc.domain.Models
{
    public class AddressSubscriptionsRel : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Subscription")]
        public int SubscriptionsId { get; set; }
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        [Display(Name = "Address Type")]
        public int AddressTypeId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }
        [Display(Name = "Primary Status")]
        public int? PrimaryStatusId { get; set; }

        public virtual Address Address { get; set; }
        [Display(Name = "Address Type")]
        public virtual AddressType AddressType { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
