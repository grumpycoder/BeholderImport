using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class AddressType : StateInfo
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public virtual ICollection<AddressChapterRel> AddressChapterRels { get; set; }
        public virtual ICollection<AddressContactRel> AddressContactRels { get; set; }
        public virtual ICollection<AddressEventRel> AddressEventRels { get; set; }
        public virtual ICollection<AddressSubscriptionsRel> AddressSubscriptionsRels { get; set; }
        //public virtual ICollection<AddressVehicleTagRel> AddressVehicleTagRels { get; set; }
        public virtual ICollection<AddressPersonRel> AddressPersonRels { get; set; }
    }
}
