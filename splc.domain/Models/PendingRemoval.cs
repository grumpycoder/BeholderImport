
namespace splc.domain.Models
{
    public class PendingRemoval
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string RemovalReason { get; set; }
        public string Username { get; set; }
    }
}
