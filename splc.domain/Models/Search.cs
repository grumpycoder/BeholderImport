using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Search
    {
        public int Id { get; set; }
        [Display(Name = "Entity")]
        public string Entity { get; set; }
        [Display(Name = "Controller")]
        public string Controller { get; set; }
        [Display(Name = "Name")]
        public string EntityName { get; set; }
        [Display(Name = "Description")]
        public string EntityDesc { get; set; }
        [Display(Name = "Entity Type")]
        public string EntityType { get; set; }
        [Display(Name = "Movement")]
        public string MovementClass { get; set; }
        [Display(Name = "Approval Status")]
        public string ApprovalStatus { get; set; }
        [Display(Name = "Active Status")]
        public string ActiveStatus { get; set; }

    }
}
