using System.ComponentModel.DataAnnotations;

namespace splc.domain
{
    public class PhoneType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}