using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class OrganizationEventRelMap : EntityTypeConfiguration<OrganizationEventRel>
    {
        public OrganizationEventRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrganizationEventRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.OrganizationId).HasColumnName("OrganizationId");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.OrganizationEventRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Event)
                .WithMany(t => t.OrganizationEventRels)
                .HasForeignKey(d => d.EventId);
            this.HasRequired(t => t.Organization)
                .WithMany(t => t.OrganizationEventRels)
                .HasForeignKey(d => d.OrganizationId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.OrganizationEventRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.OrganizationEventRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
