using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class SubscriptionComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual Subscription Subscription { get; set; }
    }
}
