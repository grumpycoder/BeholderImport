using System.ComponentModel.DataAnnotations;

namespace splc.domain
{
    public class GroupType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Group Type")]
        public string Name { get; set; }
    }
}