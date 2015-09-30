using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class PersonComment : StateInfo
    {
        [Key]
        public int Id { get; set; }
        public int BeholderPersonId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual BeholderPerson BeholderPerson { get; set; }
    }
}
