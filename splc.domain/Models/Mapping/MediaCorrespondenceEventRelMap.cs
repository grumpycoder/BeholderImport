using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaCorrespondenceEventRelMap : EntityTypeConfiguration<MediaCorrespondenceEventRel>
    {
        public MediaCorrespondenceEventRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaCorrespondenceEventRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.MediaCorrespondenceEventRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Event)
                .WithMany(t => t.MediaCorrespondenceEventRels)
                .HasForeignKey(d => d.EventId);
            this.HasRequired(t => t.MediaCorrespondence)
                .WithMany(t => t.MediaCorrespondenceEventRels)
                .HasForeignKey(d => d.MediaCorrespondenceId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.MediaCorrespondenceEventRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.MediaCorrespondenceEventRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
