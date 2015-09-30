using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaPublishedMediaCorrespondenceRelMap : EntityTypeConfiguration<MediaPublishedMediaCorrespondenceRel>
    {
        public MediaPublishedMediaCorrespondenceRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaPublishedMediaCorrespondenceRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaPublishedId).HasColumnName("MediaPublishedId");
            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.MediaPublishedMediaCorrespondenceRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaCorrespondence)
                .WithMany(t => t.MediaPublishedMediaCorrespondenceRels)
                .HasForeignKey(d => d.MediaCorrespondenceId);
            this.HasRequired(t => t.MediaPublished)
                .WithMany(t => t.MediaPublishedMediaCorrespondenceRels)
                .HasForeignKey(d => d.MediaPublishedId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.MediaPublishedMediaCorrespondenceRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.MediaPublishedMediaCorrespondenceRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
