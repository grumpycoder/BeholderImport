using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.VIN)
                .HasMaxLength(20);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vehicle", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VehicleMakeId).HasColumnName("VehicleMakeId");
            this.Property(t => t.VehicleModelId).HasColumnName("VehicleModelId");
            this.Property(t => t.VehicleTypeId).HasColumnName("VehicleTypeId");
            this.Property(t => t.VehicleColorId).HasColumnName("VehicleColorId");
            this.Property(t => t.VIN).HasColumnName("VIN");
            this.Property(t => t.VehicleYear).HasColumnName("VehicleYear");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            this.Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.VehiclesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.VehiclesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.VehiclesModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasOptional(t => t.VehicleColor)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleColorId);
            this.HasOptional(t => t.VehicleMake)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleMakeId);
            this.HasOptional(t => t.VehicleModel)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleModelId);
            this.HasOptional(t => t.VehicleType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleTypeId);

        }
    }
}
