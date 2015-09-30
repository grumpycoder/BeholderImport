using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ContactMediaCorrespondenceRelMap : EntityTypeConfiguration<ContactMediaCorrespondenceRel>
    {
        public ContactMediaCorrespondenceRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ContactMediaCorrespondenceRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.ContactMediaCorrespondenceRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Contact)
                .WithMany(t => t.ContactMediaCorrespondenceRels)
                .HasForeignKey(d => d.ContactId);
            this.HasRequired(t => t.MediaCorrespondence)
                .WithMany(t => t.ContactMediaCorrespondenceRels)
                .HasForeignKey(d => d.MediaCorrespondenceId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ContactMediaCorrespondenceRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.ContactMediaCorrespondenceRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
