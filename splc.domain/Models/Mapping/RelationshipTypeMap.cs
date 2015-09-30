using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class RelationshipTypeMap : EntityTypeConfiguration<RelationshipType>
    {
        public RelationshipTypeMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            ToTable("RelationshipType", "Beholder");
            Property(t => t.Id).HasColumnName("Id");

            Property(t => t.ObjectTo).HasColumnName("ObjectTo");
            Property(t => t.ObjectFrom).HasColumnName("ObjectFrom");
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
                .WithMany(t => t.RelationshipTypesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.DeletedUser)
                .WithMany(t => t.RelationshipTypesDeleted)
                .HasForeignKey(d => d.DeletedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.RelationshipTypesModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}