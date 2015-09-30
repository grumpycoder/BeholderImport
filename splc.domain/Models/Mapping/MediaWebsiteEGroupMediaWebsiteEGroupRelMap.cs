using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaWebsiteEGroupMediaWebsiteEGroupRelMap : EntityTypeConfiguration<MediaWebsiteEGroupMediaWebsiteEGroupRel>
    {
        public MediaWebsiteEGroupMediaWebsiteEGroupRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaWebsiteEGroupMediaWebsiteEGroupRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MediaWebsiteEGroupId).HasColumnName("MediaWebsiteEGroupId");
            this.Property(t => t.MediaWebsiteEGroup2Id).HasColumnName("MediaWebsiteEGroup2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.MediaWebsiteEGroupMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaWebsiteEGroup)
                .WithMany(t => t.MediaWebsiteEGroupMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.MediaWebsiteEGroupId);
            this.HasRequired(t => t.MediaWebsiteEGroup2)
                .WithMany(t => t.MediaWebsiteEGroupMediaWebsiteEGroupRels2)
                .HasForeignKey(d => d.MediaWebsiteEGroup2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.MediaWebsiteEGroupMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.MediaWebsiteEGroupMediaWebsiteEGroupRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
