using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaPublishedComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int MediaPublishedId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual MediaPublished MediaPublished { get; set; }
    }
}
