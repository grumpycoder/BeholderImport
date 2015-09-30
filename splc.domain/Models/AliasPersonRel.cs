using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class AliasPersonRel : StateInfo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Person")]
        public int PersonId { get; set; }
        [Display(Name = "Alias")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Alias is required")]
        public int AliasId { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("PersonHasPrimaryAlias", "Validation", AdditionalFields = "Id, PersonId", ErrorMessage = "Person already has primary alias.", HttpMethod = "POST")]
        public int? PrimaryStatusId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        //[GreaterThan("FirstKnownUseDate", PassOnNull = true, ErrorMessage = "Last Known Use Date must be greater than First Known Use Date")]
        public DateTime? LastKnownUseDate { get; set; }

        [Display(Name = "Alias")]
        [Remote("PersonHasSameAlias", "Validation", AdditionalFields = "Id, AliasName, PersonId", ErrorMessage = "Person already has this alias.", HttpMethod = "POST")]
        public virtual Alias Alias { get; set; }
        [Display(Name = "Person")]
        public virtual CommonPerson CommonPerson { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }

        [NotMapped]
        public bool IsDeleted { get { return DateDeleted != null; } }
    }
}
