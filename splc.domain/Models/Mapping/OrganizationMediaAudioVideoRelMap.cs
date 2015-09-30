using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class OrganizationMediaAudioVideoRelMap : EntityTypeConfiguration<OrganizationMediaAudioVideoRel>
    {
        public OrganizationMediaAudioVideoRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrganizationMediaAudioVideoRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.MediaAudioVideoId).HasColumnName("MediaAudioVideoId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.OrganizationMediaAudioVideoRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaAudioVideo)
                .WithMany(t => t.OrganizationMediaAudioVideoRels)
                .HasForeignKey(d => d.MediaAudioVideoId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.OrganizationMediaAudioVideoRels)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.OrganizationMediaAudioVideoRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.OrganizationMediaAudioVideoRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
