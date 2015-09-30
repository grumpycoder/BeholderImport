using System;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class EventComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Event")]
        public int EventId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual Event Event { get; set; }
    }
}
