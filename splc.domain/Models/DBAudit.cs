using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace splc.domain.Models
{
    public partial class DBAudit
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Revision Stamp")]
        public DateTime RevisionStamp { get; set; }
        [Display(Name = "Table Name")]
        public string TableName { get; set; }
        [Display(Name = "Key Value")]
        public int? KeyValue { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Actions")]
        public string Actions { get; set; }
        [Display(Name = "Old Data")]
        public string OldData { get; set; }
        [Display(Name = "New Data")]
        public string NewData { get; set; }
        [Display(Name = "Changed Columns")]
        public string ChangedColumns { get; set; }

    }
}