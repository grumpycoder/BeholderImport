using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Foolproof;
using splc.domain.Validators;

namespace splc.domain.Models
{
    public partial class CommonPerson : StateInfo
    {

        public CommonPerson()
        {
            //this.Contacts = new List<Contact>();
            //this.People = new List<Person>();
            this.AddressPersonRels = new List<AddressPersonRel>();
            this.AliasPersonRels = new List<AliasPersonRel>();
            //this.ContactInfoPersonRels = new List<ContactInfoPersonRel>();

            //this.Users = new List<User>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(9, ErrorMessage = "SSN can be no longer than 9 digits")]
        [RegularExpression(@"^[\dX]{9}$", ErrorMessage = "SSN must be 9 digits but can contain an 'X' for missing digits.")]
        public string SSN { get; set; }
        [Display(Name = "Prefix")]
        public int? PrefixId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name required")]
        [RegularExpression(@"^([a-zA-Z]+\s)*[a-zA-Z]+$", ErrorMessage = "Only characters A-Z allowed")]
        public string FName { get; set; }
        [Display(Name = "Middle Name")]
        [RegularExpression(@"^([a-zA-Z]+\s)*[a-zA-Z]+$", ErrorMessage = "Only characters A-Z allowed")]
        public string MName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name required")]
        [RegularExpression(@"^([a-zA-Z]+\s)*[a-zA-Z]+$", ErrorMessage = "Only characters A-Z allowed")]
        public string LName { get; set; }
        [Display(Name = "Suffix")]
        public int? SuffixId { get; set; }
        [NotMapped]
        public string FullName { get { return string.Format("{0}, {1}", LName.Trim(), FName); } }
        [Display(Name = "Date of Birth")]
        //[FutureDate(ErrorMessage = "DOB can not be in the future.")]
        //[Range(typeof(DateTime), "01/01/1900", "5/1/2014", ErrorMessage = "Invalid date range.")]
        //[DateRange("05/01/2014")]
        [FutureDate]
        ////[LessThan("DOB", PassOnNull = true, ErrorMessage = "Deceased date must be greater than DOB.")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Actual DOB")]
        //[BooleanRequired(ErrorMessage = "Actual DOB is required.")]
        public bool? ActualDOBIndicator { get; set; }
        [Display(Name = "Deceased Date")]
        ////[GreaterThan("DOB", PassOnNull = true, ErrorMessage = "Deceased date must be greater than DOB.")]
        [FutureDate]
        public DateTime? DeceasedDate { get; set; }
        [Display(Name = "Actual Deceased")]
        public bool? ActualDeceasedDateIndicator { get; set; }
        [Display(Name = "License Type")]
        public int? LicenseTypeId { get; set; }
        [Display(Name = "Driver License Number")]
        public string DriversLicenseNumber { get; set; }
        [Display(Name = "Driver State")]
        public int? DriversLicenseStateId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        [Display(Name = "Marital Status")]
        public int? MaritialStatusId { get; set; }
        [Display(Name = "Gender")]
        public int? GenderId { get; set; }
        [Display(Name = "Hair Color")]
        public int? HairColorId { get; set; }
        [Display(Name = "Hair Pattern")]
        public int? HairPatternId { get; set; }
        [Display(Name = "Eye Color")]
        public int? EyeColorId { get; set; }
        [Display(Name = "Race")]
        public int? RaceId { get; set; }
        //public int? OldId { get; set; }
        [Display(Name = "Eye Color")]
        public virtual EyeColor EyeColor { get; set; }
        public virtual Gender Gender { get; set; }
        [Display(Name = "Hair Color")]
        public virtual HairColor HairColor { get; set; }
        [Display(Name = "Hair Pattern")]
        public virtual HairPattern HairPattern { get; set; }
        [Display(Name = "License Type")]
        public virtual LicenseType LicenseType { get; set; }
        [Display(Name = "Marital Status")]
        public virtual MaritialStatus MaritialStatus { get; set; }
        public virtual Prefix Prefix { get; set; }
        public virtual Race Race { get; set; }
        public virtual State State { get; set; }
        public virtual Suffix Suffix { get; set; }

        public virtual ICollection<BeholderPerson> BeholderPersons { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<AddressPersonRel> AddressPersonRels { get; set; }
        public virtual ICollection<AliasPersonRel> AliasPersonRels { get; set; }
        public virtual ICollection<ContactInfoPersonRel> ContactInfoPersonRels { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }

}
