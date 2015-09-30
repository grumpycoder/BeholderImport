using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaCorrespondenceMediaWebsiteEGroupRelMap : EntityTypeConfiguration<MediaCorrespondenceMediaWebsiteEGroupRel>
    {
        public MediaCorrespondenceMediaWebsiteEGroupRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaCorrespondenceMediaWebsiteEGroupRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");
            this.Property(t => t.MediaWebsiteEGroupId).HasColumnName("MediaWebsiteEGroupId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.MediaCorrespondenceMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaCorrespondence)
                .WithMany(t => t.MediaCorrespondenceMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.MediaCorrespondenceId);
            this.HasRequired(t => t.MediaWebsiteEGroup)
                .WithMany(t => t.MediaCorrespondenceMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.MediaWebsiteEGroupId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.MediaCorrespondenceMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.MediaCorrespondenceMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
