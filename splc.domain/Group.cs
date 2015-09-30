using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splc.domain
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public int GroupTypeId { get; set; }
        public virtual GroupType GroupType { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual int ApprovalStatusId { get; set; }
        public virtual ApprovalStatus ApprovalStatus { get; set; }

        public virtual int ActiveStatusId { get; set; }
        public virtual ActiveStatus ActiveStatus { get; set; }

        public int ActiveYear { get; set; }
        
        public DateTime? FormedDate { get; set; }
        public DateTime? DisbandDate { get; set; }

        public int MovementClassId { get; set; }
        public virtual MovementClass MovementClass { get; set; }

        public int ConfidentialityTypeId { get; set; }
        public virtual ConfidentialityType ConfidentialityType { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public IList<Alias> Aliases { get; set; }

    }
}
