using System.Web.Mvc;
using Foolproof;
using System;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class AliasOrganizationRel : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int AliasId { get; set; }
        [Display(Name = "Primary Status")]
        [Remote("OrganizationHasPrimaryAlias", "Validation", AdditionalFields = "Id, OrganizationId", ErrorMessage = "Organization already has primary alias.", HttpMethod = "POST")]
        public int? PrimaryStatusId { get; set; }
        [Display(Name = "First Used")]
        //[LessThan("LastKnownUseDate", PassOnNull = true, ErrorMessage = "First Used Date must be less than Last Used Date.")]
        public DateTime? FirstKnownUseDate { get; set; }
        [Display(Name = "Last Used")]
        public DateTime? LastKnownUseDate { get; set; }

        [Display(Name = "Alias")]
        public virtual Alias Alias { get; set; }
        public virtual Organization Organization { get; set; }
        [Display(Name = "Primary Status")]
        public virtual PrimaryStatus PrimaryStatus { get; set; }
    }
}
