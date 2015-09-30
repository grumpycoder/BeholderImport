using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class PersonEventRelMap : EntityTypeConfiguration<PersonEventRel>
    {
        public PersonEventRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PersonEventRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            // Relationships
            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.PersonEventRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasRequired(t => t.Event)
                .WithMany(t => t.PersonEventRels)
                .HasForeignKey(d => d.EventId);
            this.HasRequired(t => t.BeholderPerson)
                .WithMany(t => t.PersonEventRels)
                .HasForeignKey(d => d.PersonId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.PersonEventRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.PersonEventRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
