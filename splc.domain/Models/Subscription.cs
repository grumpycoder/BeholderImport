using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Subscription : StateInfo
    {
        public Subscription()
        {
            //this.AddressSubscriptionsRels = new List<AddressSubscriptionsRel>();
            //this.ChapterSubscriptionRels = new List<ChapterSubscriptionRel>();
            //this.ContactSubscriptionRels = new List<ContactSubscriptionRel>();
            //this.EventSubscriptionRels = new List<EventSubscriptionRel>();
            //this.MediaCorrespondenceSubscriptionRels = new List<MediaCorrespondenceSubscriptionRel>();
            //this.MediaImageSubscriptionRels = new List<MediaImageSubscriptionRel>();
            //this.MediaPublishedSubscriptionRels = new List<MediaPublishedSubscriptionRel>();
            //this.MediaWebsiteEGroupSubscriptionRels = new List<MediaWebsiteEGroupSubscriptionRel>();
            //this.OrganizationSubscriptionRels = new List<OrganizationSubscriptionRel>();
            //this.PersonSubscriptionRels = new List<PersonSubscriptionRel>();
            //this.SubscriptionComments = new List<SubscriptionComment>();
            //this.SubscriptionSubscriptionRels = new List<SubscriptionSubscriptionRel>();
            //this.SubscriptionSubscriptionRels2 = new List<SubscriptionSubscriptionRel>();
            //this.SubscriptionVehicleRels = new List<SubscriptionVehicleRel>();
        }

        public int Id { get; set; }
        public int? OrderIdOld { get; set; }
        [Display(Name = "Publication Name")]
        public string PublicationName { get; set; }
        [Display(Name = "Active Status")]
        public int? ActiveStatusId { get; set; }
        [Display(Name = "Renewal Permission Date")]
        public DateTime? RenewalPermissionDate { get; set; }
        [Display(Name = "Subscription Rate")]
        [RegularExpression(@"^\d+.\d{0,2}$", ErrorMessage = "Enter a valid dollar amount.")]
        [Range(0, 9999999999999999.99, ErrorMessage = "Enter a valid dollar amount.")]
        public string SubscriptionRate { get; set; }
        [Display(Name = "Removal Status")]
        public int? RemovalStatusId { get; set; }
        [Display(Name = "Removal Reason")]
        [DataType(DataType.MultilineText)]
        public string RemovalReason { get; set; }

        [Display(Name = "Active Status")]
        public virtual ActiveStatus ActiveStatus { get; set; }
        [Display(Name = "Removal Status")]
        public virtual RemovalStatus RemovalStatus { get; set; }

        public virtual ICollection<AddressSubscriptionsRel> AddressSubscriptionsRels { get; set; }
        public virtual ICollection<ChapterSubscriptionRel> ChapterSubscriptionRels { get; set; }
        public virtual ICollection<ContactSubscriptionRel> ContactSubscriptionRels { get; set; }
        public virtual ICollection<EventSubscriptionRel> EventSubscriptionRels { get; set; }
        public virtual ICollection<MediaCorrespondenceSubscriptionRel> MediaCorrespondenceSubscriptionRels { get; set; }
        public virtual ICollection<MediaImageSubscriptionRel> MediaImageSubscriptionRels { get; set; }
        public virtual ICollection<MediaPublishedSubscriptionRel> MediaPublishedSubscriptionRels { get; set; }
        public virtual ICollection<MediaWebsiteEGroupSubscriptionRel> MediaWebsiteEGroupSubscriptionRels { get; set; }
        public virtual ICollection<OrganizationSubscriptionRel> OrganizationSubscriptionRels { get; set; }
        public virtual ICollection<SubscriptionComment> SubscriptionComments { get; set; }
        public virtual ICollection<SubscriptionSubscriptionRel> SubscriptionSubscriptionRels { get; set; }
        public virtual ICollection<SubscriptionSubscriptionRel> SubscriptionSubscriptionRels2 { get; set; }
        public virtual ICollection<SubscriptionVehicleRel> SubscriptionVehicleRels { get; set; }
    }
}
