using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ContactComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int ContactId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
