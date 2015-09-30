using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class EventVehicleRelMap : EntityTypeConfiguration<EventVehicleRel>
    {
        public EventVehicleRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EventVehicleRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.EventVehicleRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventVehicleRels)
                .HasForeignKey(d => d.EventId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.EventVehicleRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.EventVehicleRels)
                .HasForeignKey(d => d.RelationshipTypeId);
            this.HasRequired(t => t.Vehicle)
                .WithMany(t => t.EventVehicleRels)
                .HasForeignKey(d => d.VehicleId);

        }
    }
}
