using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class AudioVideoType : StateInfo
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }
        public virtual ICollection<MediaAudioVideo> MediaAudioVideos { get; set; }
    }
}
