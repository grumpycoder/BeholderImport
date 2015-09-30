using System.Data.Entity.ModelConfiguration;
namespace splc.domain.Models.Mapping
{
    public class EventReportMap : EntityTypeConfiguration<EventReport>
    {
        public EventReportMap()
        {
            HasKey(t => t.RowNum);
            // Table & Column Mappings
            ToTable("v_EventReport", "Beholder");
        }
    }
}
