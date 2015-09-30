using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaPublishedMap : EntityTypeConfiguration<MediaPublished>
    {
        public MediaPublishedMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(200);

            this.Property(t => t.Author)
                .HasMaxLength(80);

            this.Property(t => t.RenewalPermission)
                .HasMaxLength(500);

            this.Property(t => t.Summary)
                .HasMaxLength(4000);

            this.Property(t => t.City)
                .HasMaxLength(40);

            this.Property(t => t.County)
                .HasMaxLength(40);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MediaPublished", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaTypeId).HasColumnName("MediaTypeId");
            this.Property(t => t.PublishedTypeId).HasColumnName("PublishedTypeId");
            this.Property(t => t.LibraryCategoryTypeId).HasColumnName("LibraryCategoryTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DatePublished).HasColumnName("DatePublished");
            this.Property(t => t.DateReceived).HasColumnName("DateReceived");
            this.Property(t => t.Author).HasColumnName("Author");
            this.Property(t => t.NewsSourceId).HasColumnName("NewsSourceId");
            this.Property(t => t.MovementClassId).HasColumnName("MovementClassId");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.DateRenewalPermission).HasColumnName("DateRenewalPermission");
            this.Property(t => t.RenewalPermissionTypeId).HasColumnName("RenewalPermissionTypeId");
            this.Property(t => t.RenewalPermission).HasColumnName("RenewalPermission");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.County).HasColumnName("County");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            this.Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");
            this.Property(t => t.MediaPublishedContextId).HasColumnName("MediaPublishedContextId");
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");

            // Relationships
            this.HasRequired(t => t.ConfidentialityType)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasOptional(t => t.LibraryCategoryType)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.LibraryCategoryTypeId);
            this.HasRequired(t => t.MediaType)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.MediaTypeId);
            this.HasOptional(t => t.MovementClass)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.MovementClassId);
            this.HasOptional(t => t.NewsSource)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.NewsSourceId);
            this.HasOptional(t => t.PublishedType)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.PublishedTypeId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasOptional(t => t.RenewalPermmisionType)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.RenewalPermissionTypeId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.MediaPublisheds)
                .HasForeignKey(d => d.StateId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.MediaPublishedsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.MediaPublishedsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.MediaPublishedsModified)
                .HasForeignKey(d => d.ModifiedUserId);
            //this.HasOptional(t => t.MediaPublishedContext)
            //    .WithMany(t => t.MediaPublisheds)
            //    .HasForeignKey(d => d.MediaPublishedContextId);

            //this.HasOptional(t => t.MediaPublishedContext_Index)
            //    .WithMany(t => t.MediaPublisheds)
            //    .HasForeignKey(d => d.MediaPublishedContextId);

        }
    }
}
