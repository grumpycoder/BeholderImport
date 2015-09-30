using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace splc.domain
{
    public class Enrollment
    {
        [Key]
        public int Id { get; set; }

        //[Key, Column(Order = 0)]
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        //[Key, Column(Order = 1)]
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateEnrolled { get; set; }

    }
}
