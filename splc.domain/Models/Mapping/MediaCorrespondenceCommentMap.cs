using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaCorrespondenceCommentMap : EntityTypeConfiguration<MediaCorrespondenceComment>
    {
        public MediaCorrespondenceCommentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Comment)
                .IsRequired()
                .HasMaxLength(4000);

            // Table & Column Mappings
            this.ToTable("MediaCorrespondenceComment", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");
            this.Property(t => t.Comment).HasColumnName("Comment");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.MediaCorrespondence)
                .WithMany(t => t.MediaCorrespondenceComments)
                .HasForeignKey(d => d.MediaCorrespondenceId);
            this.HasOptional(t => t.CreatedUser)
                .WithMany(t => t.MediaCorrespondenceCommentsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.MediaCorrespondenceCommentsModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.MediaCorrespondenceCommentsDeleted)
                .HasForeignKey(d => d.DeletedUserId);

        }
    }
}
