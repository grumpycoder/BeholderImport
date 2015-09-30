
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaImageMap : EntityTypeConfiguration<MediaImage>
    {
        public MediaImageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ImageTitle)
                .HasMaxLength(100);

            this.Property(t => t.PhotographerArtist)
                .HasMaxLength(80);

            this.Property(t => t.RollFrameNumber)
                .HasMaxLength(15);

            this.Property(t => t.ContactOwner)
                .HasMaxLength(80);

            this.Property(t => t.RenewalPermission)
                .HasMaxLength(500);

            this.Property(t => t.Summary)
                .HasMaxLength(4000);

            this.Property(t => t.City)
                .HasMaxLength(40);

            this.Property(t => t.County)
                .HasMaxLength(40);

            this.Property(t => t.ImageFileName)
                .HasMaxLength(100);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MediaImage", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaTypeId).HasColumnName("MediaTypeId");
            this.Property(t => t.ImageTypeId).HasColumnName("ImageTypeId");
            this.Property(t => t.ImageTitle).HasColumnName("ImageTitle");
            this.Property(t => t.PhotographerArtist).HasColumnName("PhotographerArtist");
            this.Property(t => t.DatePublished).HasColumnName("DatePublished");
            this.Property(t => t.RollFrameNumber).HasColumnName("RollFrameNumber");
            this.Property(t => t.NewsSourceId).HasColumnName("NewsSourceId");
            this.Property(t => t.ContactOwner).HasColumnName("ContactOwner");
            this.Property(t => t.MovementClassId).HasColumnName("MovementClassId");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.DateRenewalPermission).HasColumnName("DateRenewalPermission");
            this.Property(t => t.RenewalPermissionTypeId).HasColumnName("RenewalPermissionTypeId");
            this.Property(t => t.RenewalPermission).HasColumnName("RenewalPermission");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.County).HasColumnName("County");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.BatchSortOrder).HasColumnName("BatchSortOrder");
            this.Property(t => t.ImageFileName).HasColumnName("ImageFileName");
            this.Property(t => t.DateTaken).HasColumnName("DateTaken");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            this.Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");
            this.Property(t => t.ImageId).HasColumnName("ImageId");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");

            // Relationships
            this.HasRequired(t => t.ConfidentialityType)
                .WithMany(t => t.MediaImages)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            //this.HasOptional(t => t.Image)
            //    .WithMany(t => t.MediaImages)
            //    .HasForeignKey(d => d.ImageId);
            this.HasOptional(t => t.ImageType)
                .WithMany(t => t.MediaImages)
                .HasForeignKey(d => d.ImageTypeId);
            this.HasRequired(t => t.MediaType)
                .WithMany(t => t.MediaImages)
                .HasForeignKey(d => d.MediaTypeId);
            this.HasOptional(t => t.MovementClass)
                .WithMany(t => t.MediaImages)
                .HasForeignKey(d => d.MovementClassId);
            this.HasOptional(t => t.NewsSource)
                .WithMany(t => t.MediaImages)
                .HasForeignKey(d => d.NewsSourceId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.MediaImages)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasOptional(t => t.RenewalPermmisionType)
                .WithMany(t => t.MediaImages)
                .HasForeignKey(d => d.RenewalPermissionTypeId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.MediaImages)
                .HasForeignKey(d => d.StateId);
            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.MediaImagesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.MediaImagesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.MediaImagesModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
