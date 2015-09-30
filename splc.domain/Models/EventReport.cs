
using System;
namespace splc.domain.Models
{
    public class EventReport
    {
        public int RowNum { get; set; }
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Summary { get; set; }
        public DateTime? EventDate { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string WebIncidentType { get; set; }
        public string ApprovalStatus { get; set; }
    }
}
