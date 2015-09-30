using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Image : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Mime Type")]
        public int MimeTypeId { get; set; }
        [Display(Name = "Confidentiality Type")]
        public Nullable<int> ConfidentialityTypeId { get; set; }
        [Display(Name = "Image")]
        public byte[] IMAGE1 { get; set; }
        public Nullable<int> OLD_OBJECT_ID { get; set; }

        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual ICollection<MediaImage> MediaImages { get; set; }
        public virtual MimeType MimeType { get; set; }
    }
}
