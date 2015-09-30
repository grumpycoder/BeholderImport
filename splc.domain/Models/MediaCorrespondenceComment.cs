using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaCorrespondenceComment : StateInfo
    {
        public int Id { get; set; }
        public int MediaCorrespondenceId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual MediaCorrespondence MediaCorrespondence { get; set; }
    }
}
