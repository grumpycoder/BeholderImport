using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Foolproof;

namespace splc.domain.Models
{
    public partial class AliasChapterRel :StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Chapter")]
        public int ChapterId { get; set; }
        [Display(Name = "Alias")]
        public int AliasId { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("ChapterHasPrimaryAlias", "Validation", AdditionalFields = "Id, ChapterId", ErrorMessage = "Chapter already has primary alias.", HttpMethod = "POST")]
        public int? PrimaryStatusId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }

        public virtual Alias Alias { get; set; }
        public virtual Chapter Chapter { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }

    }
}
