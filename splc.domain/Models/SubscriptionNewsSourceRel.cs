using System;
using System.Collections.Generic;

namespace splc.domain.Models
{
    public class SubscriptionNewsSourceRel
    {
        public long Id { get; set; }
        public int SubscriptionId { get; set; }
        public int NewsSourceId { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public int RelationshipTypeId { get; set; }
        public Nullable<int> ApprovalStatusId { get; set; }
        public Nullable<int> PrimaryStatusId { get; set; }
        public virtual ApprovalStatu ApprovalStatu { get; set; }
        public virtual NewsSource NewsSource { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }
        public virtual Subscription Subscription { get; set; }
        public virtual PrimaryStatu PrimaryStatu { get; set; }
    }
}
