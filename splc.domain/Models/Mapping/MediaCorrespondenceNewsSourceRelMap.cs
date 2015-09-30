using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaCorrespondenceNewsSourceRelMap : EntityTypeConfiguration<MediaCorrespondenceNewsSourceRel>
    {
        public MediaCorrespondenceNewsSourceRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaCorrespondenceNewsSourceRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");
            this.Property(t => t.NewsSourceId).HasColumnName("NewsSourceId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatu)
                .WithMany(t => t.MediaCorrespondenceNewsSourceRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaCorrespondence)
                .WithMany(t => t.MediaCorrespondenceNewsSourceRels)
                .HasForeignKey(d => d.MediaCorrespondenceId);
            this.HasRequired(t => t.NewsSource)
                .WithMany(t => t.MediaCorrespondenceNewsSourceRels)
                .HasForeignKey(d => d.NewsSourceId);
            this.HasOptional(t => t.PrimaryStatu)
                .WithMany(t => t.MediaCorrespondenceNewsSourceRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.MediaCorrespondenceNewsSourceRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
