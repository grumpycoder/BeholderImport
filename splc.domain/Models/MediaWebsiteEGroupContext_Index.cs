using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain.Models
{
    [Table("Beholder.v_MediaWebsiteEGroupContext")]
    public partial class MediaWebsiteEGroupContext_Index
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Context Text")]
        public string ContextText { get; set; }

        public int? MediaWebsiteEGroupId { get; set; }

        public virtual MediaWebsiteEGroup MediaWebsiteEGroup { get; set; }

        //public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
    }
}
