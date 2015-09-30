using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class OrganizationPersonRelMap : EntityTypeConfiguration<OrganizationPersonRel>
    {
        public OrganizationPersonRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrganizationPersonRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.OrganizationPersonRels)
                .HasForeignKey(d => d.OrganizationId);
            this.HasRequired(t => t.BeholderPerson)
                .WithMany(t => t.OrganizationPersonRels)
                .HasForeignKey(d => d.PersonId);
            this.HasOptional(t => t.RelationshipType)
                .WithMany(t => t.OrganizationPersonRels)
                .HasForeignKey(d => d.RelationshipTypeId);
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.OrganizationPersonRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.OrganizationPersonRels)
                .HasForeignKey(d => d.PrimaryStatusId);

        }
    }
}
