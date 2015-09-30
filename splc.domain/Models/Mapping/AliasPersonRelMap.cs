using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class AliasPersonRelMap : EntityTypeConfiguration<AliasPersonRel>
    {
        public AliasPersonRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            this.Property(t => t.FirstKnownUseDate)
                .IsRequired();



            // Properties
            // Table & Column Mappings
            this.ToTable("AliasPersonRel", "Common");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
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
                .WithMany(t => t.AliasPersonRels)
                .HasForeignKey(d => d.AliasId);
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.AliasPersonRelsCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.AliasPersonRelsDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.AliasPersonRelsModified)
                .HasForeignKey(d => d.ModifiedUserId);
            this.HasRequired(t => t.CommonPerson)
                .WithMany(t => t.AliasPersonRels)
                .HasForeignKey(d => d.PersonId);
            this.HasOptional(t => t.PrimaryStatus)
                .WithMany(t => t.AliasPersonRels)
                .HasForeignKey(d => d.PrimaryStatusId);

        }
    }
}
