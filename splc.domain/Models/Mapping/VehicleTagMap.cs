using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class VehicleTagMap : EntityTypeConfiguration<VehicleTag>
    {
        public VehicleTagMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TagNumber)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.Address1)
                .HasMaxLength(256);

            this.Property(t => t.Address2)
                .HasMaxLength(256);

            this.Property(t => t.City)
                .HasMaxLength(256);

            this.Property(t => t.County)
                .HasMaxLength(256);

            this.Property(t => t.Zip5)
                .IsFixedLength()
                .HasMaxLength(5);

            this.Property(t => t.Zip4)
                .IsFixedLength()
                .HasMaxLength(4);

            // Table & Column Mappings
            this.ToTable("VehicleTag", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
            this.Property(t => t.TagNumber).HasColumnName("TagNumber");
            this.Property(t => t.TagTypeId).HasColumnName("TagTypeId");
            this.Property(t => t.IssueYear).HasColumnName("IssueYear");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.County).HasColumnName("County");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.Zip5).HasColumnName("Zip5");
            this.Property(t => t.Zip4).HasColumnName("Zip4");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.TagType)
                .WithMany(t => t.VehicleTags)
                .HasForeignKey(d => d.TagTypeId);
            this.HasRequired(t => t.Vehicle)
                .WithMany(t => t.VehicleTags)
                .HasForeignKey(d => d.VehicleId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.VehicleTags)
                .HasForeignKey(d => d.StateId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.VehicleTagsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.VehicleTagsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.VehicleTagsModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
