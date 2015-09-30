using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Foolproof;

namespace splc.domain.Models
{
    public partial class PersonScreenName : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Person")]
        public int BeholderPersonId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Screen name is required")]
        [Display(Name = "Screen Name")]
        public string ScreenName { get; set; }
        [Display(Name = "Used At")]
        public string UsedAt { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("PersonHasPrimaryScreenName", "Validation", AdditionalFields = "Id, BeholderPersonId", ErrorMessage = "Person already has primary screen name.", HttpMethod = "POST")]
        public int? PrimaryStatusId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }

        [Display(Name = "Person")]
        public virtual BeholderPerson BeholderPerson { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
    }
}
