using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class VehicleCommentMap : EntityTypeConfiguration<VehicleComment>
    {
        public VehicleCommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Comment)
                .IsRequired()
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("VehicleComment", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.VehicleId).HasColumnName("VehicleId");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.Vehicle)
                .WithMany(t => t.VehicleComments)
                .HasForeignKey(d => d.VehicleId);
            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.VehicleCommentsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.VehicleCommentsModified)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.VehicleCommentsDeleted)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
