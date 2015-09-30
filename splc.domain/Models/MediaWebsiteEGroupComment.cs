using System;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaWebsiteEGroupComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int MediaWebsiteEGroupId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual MediaWebsiteEGroup MediaWebsiteEGroup { get; set; }
    }
}
