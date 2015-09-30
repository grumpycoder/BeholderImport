using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ChapterComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int ChapterId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual Chapter Chapter { get; set; }

    }
}
