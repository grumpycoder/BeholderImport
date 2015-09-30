using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterTypeMap : EntityTypeConfiguration<ChapterType>
    {
        public ChapterTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("ChapterType", "Beholder");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.Name).HasColumnName("Name");
            Property(t => t.SortOrder).HasColumnName("SortOrder");
            Property(t => t.DateCreated).HasColumnName("DateCreated");
            Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            Property(t => t.DateModified).HasColumnName("DateModified");
            Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.ChapterTypesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.ChapterTypesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.ChapterTypesModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
