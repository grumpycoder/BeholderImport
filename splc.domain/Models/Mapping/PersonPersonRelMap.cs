using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class PersonPersonRelMap : EntityTypeConfiguration<PersonPersonRel>
    {
        public PersonPersonRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PersonPersonRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.Person2Id).HasColumnName("Person2Id");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.PersonPersonRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.BeholderPerson)
                .WithMany(t => t.PersonPersonRels)
                .HasForeignKey(d => d.PersonId);
            this.HasRequired(t => t.BeholderPerson2)
                .WithMany(t => t.PersonPersonRels2)
                .HasForeignKey(d => d.Person2Id);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.PersonPersonRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.PersonPersonRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
