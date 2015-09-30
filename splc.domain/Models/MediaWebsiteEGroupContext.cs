using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class MediaWebsiteEGroupContext
    {
        public MediaWebsiteEGroupContext()
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

        public int? MediaWebsiteEGroupId { get; set; }

        //[NotMapped]
        //public string ContextTextFullTextIndexSearchField { get; set; }

        [Display(Name = "Mime Type")]
        public virtual MimeType MimeType { get; set; }

        public virtual MediaWebsiteEGroup MediaWebsiteEGroup { get; set; }

        //public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
        //public virtual MediaPublished MediaPublished { get; set; }

        //public virtual MediaPublishedContext_Index MediaPublishedContext_Index { get; set; }
    }
}
