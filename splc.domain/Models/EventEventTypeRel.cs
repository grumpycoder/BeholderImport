using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace splc.domain.Models
{
    public partial class EventEventTypeRel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Event")]
        public int EventId { get; set; }
        [Display(Name = "Event Type")]
        public int EventTypeId { get; set; }

        [Display(Name = "Event Type")]
        public virtual EventType EventType { get; set; }
        [Display(Name = "Event")]
        public virtual Event Event { get; set; }
    }
}
