using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class DropdownPersonMap : EntityTypeConfiguration<DropdownPerson>
    {
        public DropdownPersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("v_BeholderPerson", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.label).HasColumnName("DisplayName");
        }
    }
}
