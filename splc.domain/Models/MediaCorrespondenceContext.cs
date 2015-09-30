using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaCorrespondenceContext
    {
        public MediaCorrespondenceContext()
        {

        }

        public int Id { get; set; }
        [Display(Name = "Mime Type")]
        public int? MimeTypeId { get; set; }
        [Display(Name = "Document Extension")]
        public string DocumentExtension { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        [Display(Name = "ContextText")]
        public byte[] ContextText { get; set; }

        public int? MediaCorrespondenceId { get; set; }

        [Display(Name = "Mime Type")]
        public virtual MimeType MimeType { get; set; }

        public virtual MediaCorrespondence MediaCorrespondence { get; set; }

        //public virtual ICollection<MediaCorrespondence> MediaCorrespondences { get; set; }
    }
}
