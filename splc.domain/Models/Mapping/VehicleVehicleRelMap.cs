using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class VehicleVehicleRelMap : EntityTypeConfiguration<VehicleVehicleRel>
    {
        public VehicleVehicleRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("VehicleVehicleRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
            this.Property(t => t.Vehicle2Id).HasColumnName("Vehicle2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.VehicleVehicleRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.VehicleVehicleRels)
                .HasForeignKey(d => d.RelationshipTypeId);
            this.HasRequired(t => t.Vehicle)
                .WithMany(t => t.VehicleVehicleRels)
                .HasForeignKey(d => d.VehicleId);
            this.HasRequired(t => t.Vehicle2)
                .WithMany(t => t.VehicleVehicleRels2)
                .HasForeignKey(d => d.Vehicle2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.VehicleVehicleRels)
                .HasForeignKey(d => d.PrimaryStatusId);

        }
    }
}
