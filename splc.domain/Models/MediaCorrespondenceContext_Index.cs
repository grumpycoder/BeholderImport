using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain.Models
{
    [Table("Beholder.v_MediaCorrespondenceContext")]
    public partial class MediaCorrespondenceContext_Index
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ContextText")]
        public string ContextText { get; set; }

        public int? MediaCorrespondenceId { get; set; }

        public virtual MediaCorrespondence MediaCorrespondence { get; set; }

        //public virtual ICollection<MediaCorrespondence> MediaCorrespondences { get; set; }
    }
}
