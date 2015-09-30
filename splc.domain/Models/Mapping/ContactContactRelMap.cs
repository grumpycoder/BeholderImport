using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ContactContactRelMap : EntityTypeConfiguration<ContactContactRel>
    {
        public ContactContactRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ContactContactRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.Contact2Id).HasColumnName("Contact2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.ContactContactRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Contact)
                .WithMany(t => t.ContactContactRels)
                .HasForeignKey(d => d.ContactId);
            this.HasRequired(t => t.Contact2)
                .WithMany(t => t.ContactContactRels2)
                .HasForeignKey(d => d.Contact2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ContactContactRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.ContactContactRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
