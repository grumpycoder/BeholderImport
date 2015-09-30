using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaImageMediaWebsiteEGroupRelMap : EntityTypeConfiguration<MediaImageMediaWebsiteEGroupRel>
    {
        public MediaImageMediaWebsiteEGroupRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaImageMediaWebsiteEGroupRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaImageId).HasColumnName("MediaImageId");
            this.Property(t => t.MediaWebsiteEGroupId).HasColumnName("MediaWebsiteEGroupId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.MediaImageMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaImage)
                .WithMany(t => t.MediaImageMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.MediaImageId);
            this.HasRequired(t => t.MediaWebsiteEGroup)
                .WithMany(t => t.MediaImageMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.MediaWebsiteEGroupId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.MediaImageMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.MediaImageMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
