
namespace splc.domain.Models
{
    public class ChapterReport
    {
        public int RowNum { get; set; }
        public int Id { get; set; }
        public int GroupId { get; set; }
        public bool IsHeadquarters { get; set; }
        public string ChapterName { get; set; }
        public string OrganizationName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string StateCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string PrimaryStatus { get; set; }

        public int? ActiveYear { get; set; }
        public string MovementClass { get; set; }
        public string ActiveStatus { get; set; }
        public string ApprovalStatus { get; set; }

    }
}