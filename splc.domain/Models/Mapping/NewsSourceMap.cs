using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class NewsSourceMap : EntityTypeConfiguration<NewsSource>
    {
        public NewsSourceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.NewsSourceName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("NewsSource", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.NewsSourceName).HasColumnName("NewsSourceName");
            this.Property(t => t.NewsSourceTypeId).HasColumnName("NewsSourceTypeId");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            this.HasOptional(t => t.NewsSourceType)
                .WithMany(t => t.NewsSources)
                .HasForeignKey(d => d.NewsSourceTypeId);
            // Relationships
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.NewsSourcesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.NewsSourcesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.NewsSourcesModified)
                .HasForeignKey(d => d.ModifiedUserId);


        }
    }
}
