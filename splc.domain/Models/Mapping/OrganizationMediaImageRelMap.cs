using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class OrganizationMediaImageRelMap : EntityTypeConfiguration<OrganizationMediaImageRel>
    {
        public OrganizationMediaImageRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrganizationMediaImageRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.MediaImageId).HasColumnName("MediaImageId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.OrganizationMediaImageRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaImage)
                .WithMany(t => t.OrganizationMediaImageRels)
                .HasForeignKey(d => d.MediaImageId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.OrganizationMediaImageRels)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.OrganizationMediaImageRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasOptional(t => t.RelationshipType)
                .WithMany(t => t.OrganizationMediaImageRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
