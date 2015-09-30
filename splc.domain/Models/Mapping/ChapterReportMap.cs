using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterReportMap : EntityTypeConfiguration<ChapterReport>
    {
        public ChapterReportMap()
        {
            HasKey(t => t.RowNum);
            // Table & Column Mappings
            ToTable("v_ChapterReport", "Beholder");
        }
    }
}