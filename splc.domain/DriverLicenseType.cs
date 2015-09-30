
using System.ComponentModel.DataAnnotations;

namespace splc.domain
{
    public class DriverLicenseType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
