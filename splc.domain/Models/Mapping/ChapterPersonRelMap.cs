using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class ChapterPersonRelMap : EntityTypeConfiguration<ChapterPersonRel>
    {
        public ChapterPersonRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ChapterPersonRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ChapterId).HasColumnName("ChapterId");
            this.Property(t => t.BeholderPersonId).HasColumnName("PersonId");
            this.Property(t => t.DateStart).HasColumnName("DateStart");
            this.Property(t => t.DateEnd).HasColumnName("DateEnd");
            this.Property(t => t.RelationshipTypeId).HasColumnName("RelationshipTypeId");
            this.Property(t => t.ApprovalStatusId).HasColumnName("ApprovalStatusId");
            this.Property(t => t.PrimaryStatusId).HasColumnName("PrimaryStatusId");

            this.HasRequired(t => t.Chapter)
               .WithMany(t => t.ChapterPersonRels)
               .HasForeignKey(d => d.ChapterId);
            this.HasRequired(t => t.BeholderPerson)
                .WithMany(t => t.ChapterPersonRels)
                .HasForeignKey(d => d.BeholderPersonId);

            this.HasOptional(t => t.ApprovalStatus)
                .WithMany(t => t.ChapterPersonRels)
                .HasForeignKey(d => d.ApprovalStatusId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.ChapterPersonRels)
                .HasForeignKey(d => d.PrimaryStatusId);
            this.HasRequired(t => t.RelationshipType)
                .WithMany(t => t.ChapterPersonRels)
                .HasForeignKey(d => d.RelationshipTypeId);

        }
    }
}
