using System;
using System.Collections.Generic;

namespace splc.domain.Models
{
    public class MediaCorrespondenceNewsSourceRel
    {
        public long Id { get; set; }
        public int MediaCorrespondenceId { get; set; }
        public int NewsSourceId { get; set; }
        public Nullable<System.DateTime> DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public int RelationshipTypeId { get; set; }
        public Nullable<int> ApprovalStatusId { get; set; }
        public Nullable<int> PrimaryStatusId { get; set; }
        public virtual ApprovalStatus ApprovalStatus { get; set; }
        public virtual MediaCorrespondence MediaCorrespondence { get; set; }
        public virtual NewsSource NewsSource { get; set; }
        public virtual PrimaryStatus PrimaryStatus { get; set; }
        public virtual RelationshipType RelationshipType { get; set; }
    }
}
