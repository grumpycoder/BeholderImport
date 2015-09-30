using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class PendingRemovalMap : EntityTypeConfiguration<PendingRemoval>
    {
        public PendingRemovalMap()
        {
            // Primary Key
            HasKey(t => t.Id);
            // Table & Column Mappings
            ToTable("v_PendingRemoval", "Beholder");
        }
    }
}

