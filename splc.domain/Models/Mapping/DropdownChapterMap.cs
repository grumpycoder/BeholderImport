using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class DropdownChapterMap : EntityTypeConfiguration<DropdownChapter>
    {
        public DropdownChapterMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("v_Chapter", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.label).HasColumnName("ChapterName");
        }
    }
}
