using System;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class EventStatusHistory : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Event")]
        public int EventId { get; set; }
        [Display(Name = "Active Status")]
        public int ActiveStatusId { get; set; }
        [Display(Name = "Active Year")]
        public int ActiveYear { get; set; }
        [Display(Name = "Report Status")]
        public bool ReportStatusFlag { get; set; }

        [Display(Name = "Active Status")]
        public virtual ActiveStatus ActiveStatus { get; set; }
        public virtual Event Event { get; set; }
    }
}
