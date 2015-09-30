using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class OrganizationComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual Organization Organization { get; set; }

    }
}
