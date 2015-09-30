using System.ComponentModel.DataAnnotations;

namespace splc.domain
{
    public class OnlineIdentity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Service { get; set; }
        public string Comment { get; set; }
    }
}