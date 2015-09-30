using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class BeholderPersonMap : EntityTypeConfiguration<BeholderPerson>
    {
        public BeholderPersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DistinguishableMarks)
                .HasMaxLength(1012);

            this.Property(t => t.RemovalReason)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Person", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CommonPersonId).HasColumnName("PersonId");
            this.Property(t => t.MovementClassId).HasColumnName("MovementClassId");
            this.Property(t => t.ConfidentialityTypeId).HasColumnName("ConfidentialityTypeId");
            this.Property(t => t.DistinguishableMarks).HasColumnName("DistinguishableMarks");
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
                .WithMany(t => t.BeholderPersons)
                .HasForeignKey(d => d.ConfidentialityTypeId);
            this.HasOptional(t => t.MovementClass)
                .WithMany(t => t.BeholderPersons)
                .HasForeignKey(d => d.MovementClassId);
            this.HasOptional(t => t.RemovalStatus)
                .WithMany(t => t.BeholderPersons)
                .HasForeignKey(d => d.RemovalStatusId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.BeholderPersonsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.BeholderPersonsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.BeholderPersonsModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasRequired(t => t.CommonPerson)
                .WithMany(t => t.BeholderPersons)
                .HasForeignKey(d => d.CommonPersonId);
            //this.HasRequired(t => t.Person1)
            //    .WithMany(t => t.People)
            //    .HasForeignKey(d => d.CommonPersonId);

        }
    }
}
