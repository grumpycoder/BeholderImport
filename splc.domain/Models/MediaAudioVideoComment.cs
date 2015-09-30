using System;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaAudioVideoComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int MediaAudioVideoId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual MediaAudioVideo MediaAudioVideo { get; set; }
    }
}
