using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public partial class Religion : StateInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

    }
}