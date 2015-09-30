using System.ComponentModel.DataAnnotations;

namespace splc.domain
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Note { get; set; }
    }
}