
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Foolproof;

namespace splc.domain.Models
{
    public partial class AddressChapterRel : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Chapter")]
        public int ChapterId { get; set; }
        [Display(Name = "Address")]
        public int AddressId { get; set; }
        [Display(Name = "Address Type")]
        public int? AddressTypeId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("ChapterHasPrimaryAddress", "Validation", AdditionalFields = "Id, ChapterId", ErrorMessage = "Chapter already has primary address.", HttpMethod = "POST")]
        public int PrimaryStatusId { get; set; }

        [Display(Name = "Address Type")]
        public virtual AddressType AddressType { get; set; }
        public virtual Address Address { get; set; }
        public virtual Chapter Chapter { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
    }
}
