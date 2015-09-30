using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class GenderMap : EntityTypeConfiguration<Gender>
    {
        public GenderMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Gender", "Common");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.GendersCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.GendersDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.GendersModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}