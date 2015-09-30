using System;

namespace splc.domain.Models
{
    public partial class ContactEventRel
    {
        public long Id { get; set; }
        public int ContactId { get; set; }
        public int EventId { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public int RelationshipTypeId { get; set; }
        public int? ApprovalStatusId { get; set; }
        public int? PrimaryStatusId { get; set; }
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual EventIncident Event { get; set; }
        public virtual PrimaryStatus PrimaryStatus { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }
    }
}
