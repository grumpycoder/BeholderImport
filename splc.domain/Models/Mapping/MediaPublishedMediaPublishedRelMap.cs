using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaPublishedMediaPublishedRelMap : EntityTypeConfiguration<MediaPublishedMediaPublishedRel>
    {
        public MediaPublishedMediaPublishedRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaPublishedMediaPublishedRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaPublishedId).HasColumnName("MediaPublishedId");
            this.Property(t => t.MediaPublished2Id).HasColumnName("MediaPublished2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.MediaPublishedMediaPublishedRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaPublished)
                .WithMany(t => t.MediaPublishedMediaPublishedRels)
                .HasForeignKey(d => d.MediaPublishedId);
            this.HasRequired(t => t.MediaPublished2)
                .WithMany(t => t.MediaPublishedMediaPublishedRels2)
                .HasForeignKey(d => d.MediaPublished2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.MediaPublishedMediaPublishedRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.MediaPublishedMediaPublishedRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
