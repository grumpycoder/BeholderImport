using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class DBAuditMap : EntityTypeConfiguration<DBAudit>
    {
        public DBAuditMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("DBAudit", "Common");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RevisionStamp).HasColumnName("RevisionStamp");
            this.Property(t => t.TableName).HasColumnName("TableName");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Actions).HasColumnName("Actions");
            this.Property(t => t.OldData).HasColumnName("OldData");
            this.Property(t => t.NewData).HasColumnName("NewData");
            this.Property(t => t.ChangedColumns).HasColumnName("ChangedColumns");

        }
    }
}