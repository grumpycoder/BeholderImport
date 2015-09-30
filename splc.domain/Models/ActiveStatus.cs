using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class ActiveStatus : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<ChapterStatusHistory> ChapterStatusHistories { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<EventStatusHistory> EventStatusHistories { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<OrganizationStatusHistory> OrganizationStatusHistories { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<MediaWebsiteEGroup> MediaWebsiteEGroups { get; set; }
    }
}
