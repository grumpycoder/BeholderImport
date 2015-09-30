using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class NewsSourceComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int NewsSourceId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual NewsSource NewsSource { get; set; }
    }
}
