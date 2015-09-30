using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterOrganizationRelMap : EntityTypeConfiguration<ChapterOrganizationRel>
    {
        public ChapterOrganizationRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChapterOrganizationRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChapterId).HasColumnName("ChapterId");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.ChapterOrganizationRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Chapter)
                .WithMany(t => t.ChapterOrganizationRels)
                .HasForeignKey(d => d.ChapterId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.ChapterOrganizationRels)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ChapterOrganizationRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.ChapterOrganizationRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
