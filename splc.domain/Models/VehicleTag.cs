using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class VehicleTag : StateInfo
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        [Display(Name = "Tag Number")]
        public string TagNumber { get; set; }
        [Display(Name = "Tag Type")]
        public int TagTypeId { get; set; }
        [Display(Name = "Issue Year")]
        public int? IssueYear { get; set; }
        [Display(Name = "Address1")]
        public string Address1 { get; set; }
        [Display(Name = "Address2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        [Display(Name = "State")]
        public int? StateId { get; set; }
        public string Zip5 { get; set; }
        public string Zip4 { get; set; }

        public virtual TagType TagType { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual State State { get; set; }
        //public virtual ICollection<AddressVehicleTagRel> AddressVehicleTagRels { get; set; }
    }
}
