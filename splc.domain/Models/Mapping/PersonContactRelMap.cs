using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class PersonContactRelMap : EntityTypeConfiguration<PersonContactRel>
    {
        public PersonContactRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PersonContactRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.PersonContactRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Contact)
                .WithMany(t => t.PersonContactRels)
                .HasForeignKey(d => d.ContactId);
            this.HasRequired(t => t.BeholderPerson)
                .WithMany(t => t.PersonContactRels)
                .HasForeignKey(d => d.PersonId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.PersonContactRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.PersonContactRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
