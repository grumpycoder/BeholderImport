using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Profession)
                .HasMaxLength(100);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Contact", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CommonPersonId).HasColumnName("PersonId");
            this.Property(t => t.ContactIdOld).HasColumnName("ContactIdOld");
            this.Property(t => t.Profession).HasColumnName("Profession");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.ContactTypeId).HasColumnName("ContactTypeId");
            this.Property(t => t.ContactTopicId).HasColumnName("ContactTopicId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.RemovalStatusId).HasColumnName("RemovalStatusId");
            this.Property(t => t.RemovalReason).HasColumnName("RemovalReason");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasOptional(t => t.ConfidentialityType)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasOptional(t => t.ContactTopic)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.ContactTopicId);
            this.HasOptional(t => t.ContactType)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.ContactTypeId);
            this.HasRequired(t => t.CommonPerson)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.CommonPersonId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.RemovalStatusId);

            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.ContactsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.ContactsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.ContactsModified)
                .HasForeignKey(d => d.ModifiedUserId);
        }
    }
}
