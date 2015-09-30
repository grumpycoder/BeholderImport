using System.ComponentModel.DataAnnotations;

namespace splc.domain.Models
{
    public class VehicleComment : StateInfo
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comment { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
