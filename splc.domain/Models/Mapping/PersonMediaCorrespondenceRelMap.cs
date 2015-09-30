using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class PersonMediaCorrespondenceRelMap : EntityTypeConfiguration<PersonMediaCorrespondenceRel>
    {
        public PersonMediaCorrespondenceRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PersonMediaCorrespondenceRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.PersonMediaCorrespondenceRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.MediaCorrespondence)
                .WithMany(t => t.PersonMediaCorrespondenceRels)
                .HasForeignKey(d => d.MediaCorrespondenceId);
            this.HasRequired(t => t.BeholderPerson)
                .WithMany(t => t.PersonMediaCorrespondenceRels)
                .HasForeignKey(d => d.PersonId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.PersonMediaCorrespondenceRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.PersonMediaCorrespondenceRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
