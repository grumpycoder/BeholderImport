using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class AliasChapterRelMap : EntityTypeConfiguration<AliasChapterRel>
    {
        public AliasChapterRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("AliasChapterRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChapterId).HasColumnName("ChapterId");
            this.Property(t => t.AliasId).HasColumnName("AliasId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");
            this.Property(t => t.FirstKnownUseDate).HasColumnName("FirstKnownUseDate");
            this.Property(t => t.LastKnownUseDate).HasColumnName("LastKnownUseDate");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");
            this.Property(t => t.DateDeleted).HasColumnName("DateDeleted");
            this.Property(t => t.DeletedUserId).HasColumnName("DeletedUserId");

            // Relationships
            this.HasRequired(t => t.Alias)
                .WithMany(t => t.AliasChapterRels)
                .HasForeignKey(d => d.AliasId);
            this.HasRequired(t => t.Chapter)
                .WithMany(t => t.AliasChapterRels)
                .HasForeignKey(d => d.ChapterId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.AliasChapterRelsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.AliasChapterRelsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.AliasChapterRelsModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.AliasChapterRels)
                .HasForeignKey(d => d.PrimaryStatusId);

        }
    }
}
