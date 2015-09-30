using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class DropdownOrganizationMap : EntityTypeConfiguration<DropdownOrganization>
    {
        public DropdownOrganizationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("v_Organization", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.label).HasColumnName("OrganizationName");
        }
    }
}
