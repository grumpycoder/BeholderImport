using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class SearchMap : EntityTypeConfiguration<Search>
    {
        public SearchMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Table & Column Mappings
            this.ToTable("v_EntityList", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Entity).HasColumnName("Entity");
            this.Property(t => t.Controller).HasColumnName("Controller");
            this.Property(t => t.EntityName).HasColumnName("EntityName");
            this.Property(t => t.EntityDesc).HasColumnName("EntityDesc");
            this.Property(t => t.EntityType).HasColumnName("EntityType");
            this.Property(t => t.MovementClass).HasColumnName("MovementClass");
            this.Property(t => t.ApprovalStatus).HasColumnName("ApprovalStatus");
            this.Property(t => t.ActiveStatus).HasColumnName("ActiveStatus");

        }
    }
}
