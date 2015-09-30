using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaImageComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int MediaImageId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }
        [Display(Name = "Image")]
        public virtual MediaImage MediaImage { get; set; }
    }
}
