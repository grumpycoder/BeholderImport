using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Image", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MimeTypeId).HasColumnName("MimeTypeId");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.IMAGE1).HasColumnName("IMAGE");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");
            this.Property(t => t.OLD_OBJECT_ID).HasColumnName("OLD_OBJECT_ID");

            // Relationships
            this.HasOptional(t => t.ConfidentialityType)
                .WithMany(t => t.Images)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasRequired(t => t.MimeType)
                .WithMany(t => t.Images)
                .HasForeignKey(d => d.MimeTypeId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.ImagesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.ImagesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.ImagesModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
