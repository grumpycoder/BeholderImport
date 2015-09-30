using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Address : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Address")]
        [RegularExpression(@"^([a-zA-Z0-9.# \.\&\'\-]+)$", ErrorMessage = "Address contains invalid characters.")]
        public string Address1 { get; set; }
         [RegularExpression(@"^([a-zA-Z0-9.# \.\&\'\-]+)$", ErrorMessage = "Address contains invalid characters.")]
        [Display(Name = "Address")]
        public string Address2 { get; set; }
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "City contains invalid characters.")]
        public string City { get; set; }
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "County contains invalid characters.")]
        public string County { get; set; }
        [RegularExpression(@"^([a-zA-Z \.\&\'\-]+)$", ErrorMessage = "Country contains invalid characters.")]
        public string Country { get; set; }
        [Display(Name = "State")]
        public int? StateId { get; set; }
        [Display(Name = "Zip Code")]
        [RegularExpression(@"^(\d{5})$", ErrorMessage = "Enter a valid 5 digit zipcode.")]
        public string Zip5 { get; set; }
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Enter a valid 4 digit zipcode.")]
        [Display(Name = "Zip 4")]
        public string Zip4 { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

        public virtual ICollection<AddressContactRel> AddressContactRels { get; set; }
        public virtual ICollection<AddressEventRel> AddressEventRels { get; set; }
        //public virtual ICollection<AddressVehicleTagRel> AddressVehicleTagRels { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<AddressSubscriptionsRel> AddressSubscriptionsRels { get; set; }
        public virtual ICollection<AddressPersonRel> AddressPersonRels { get; set; }
    }
}
