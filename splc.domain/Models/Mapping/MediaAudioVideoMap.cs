using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaAudioVideoMap : EntityTypeConfiguration<MediaAudioVideo>
    {
        public MediaAudioVideoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.SpeakerCommentator)
                .HasMaxLength(100);

            this.Property(t => t.MediaLength)
                .HasMaxLength(15);

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
            this.ToTable("MediaAudioVideo", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaTypeId).HasColumnName("MediaTypeId");
            this.Property(t => t.AudioVideoTypeId).HasColumnName("AudioVideoTypeId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.DateReceivedRecorded).HasColumnName("DateReceivedRecorded");
            this.Property(t => t.DateAired).HasColumnName("DateAired");
            this.Property(t => t.SpeakerCommentator).HasColumnName("SpeakerCommentator");
            this.Property(t => t.MediaLength).HasColumnName("MediaLength");
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
            this.Property(t => t.CatalogId).HasColumnName("CatalogId");

            // Relationships
            this.HasRequired(t => t.AudioVideoType)
                .WithMany(t => t.MediaAudioVideos)
                .HasForeignKey(d => d.AudioVideoTypeId);
            this.HasOptional(t => t.ConfidentialityType)
                .WithMany(t => t.MediaAudioVideos)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasOptional(t => t.MovementClass)
                .WithMany(t => t.MediaAudioVideos)
                .HasForeignKey(d => d.MovementClassId);
            this.HasOptional(t => t.NewsSource)
                .WithMany(t => t.MediaAudioVideos)
                .HasForeignKey(d => d.NewsSourceId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.MediaAudioVideos)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasOptional(t => t.RenewalPermmisionType)
                .WithMany(t => t.MediaAudioVideos)
                .HasForeignKey(d => d.RenewalPermissionTypeId);
            this.HasOptional(t => t.State)
                .WithMany(t => t.MediaAudioVideos)
                .HasForeignKey(d => d.StateId);
            this.HasRequired(t => t.MediaType)
                .WithMany(t => t.MediaAudioVideos)
                .HasForeignKey(d => d.MediaTypeId);
            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.MediaAudioVideosCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.MediaAudioVideosDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.MediaAudioVideosModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
