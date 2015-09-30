using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class OrganizationOrganizationRelMap : EntityTypeConfiguration<OrganizationOrganizationRel>
    {
        public OrganizationOrganizationRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrganizationOrganizationRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.Organization2Id).HasColumnName("Organization2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.OrganizationOrganizationRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.OrganizationOrganizationRels)
                .HasForeignKey(d => d.OrganizationId);
            this.HasRequired(t => t.Organization2)
                .WithMany(t => t.OrganizationOrganizationRels2)
                .HasForeignKey(d => d.Organization2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.OrganizationOrganizationRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.OrganizationOrganizationRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
