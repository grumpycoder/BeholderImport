using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Group
    {
        public Group()
        {
            //this.GroupUsers = new List<GroupUser>();
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Security Level is required.")]
        public int? ConfidentialityTypeId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CreatedUserId { get; set; }
        public DateTime? DateModified { get; set; }
        public int? ModifiedUserId { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? DeletedUserId { get; set; }
        [Display(Name = "Security Level")]
        public virtual ConfidentialityType ConfidentialityType { get; set; }
        public virtual ICollection<GroupUser> GroupUsers { get; set; }
    }
}
