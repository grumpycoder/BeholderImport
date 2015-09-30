using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaCorrespondenceContextMap : EntityTypeConfiguration<MediaCorrespondenceContext>
    {
        public MediaCorrespondenceContextMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            //        this.MapToStoredProcedures(s =>
            //s.Insert(i => i.HasName("Beholder.p_addMediaCorrespondenceContext"))
            // .Update(u => u.HasName("Beholder.p_updMediaCorrespondenceContext")));

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaCorrespondenceContext", "Beholder");

            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MimeTypeId).HasColumnName("MimeTypeId");
            this.Property(t => t.DocumentExtension).HasColumnName("DocumentExtension");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.ContextText).HasColumnName("ContextText");
            this.Property(t => t.MediaCorrespondenceId).HasColumnName("MediaCorrespondenceId");

            // Relationships
            this.HasOptional(t => t.MimeType)
                .WithMany(t => t.MediaCorrespondenceContexts)
                .HasForeignKey(d => d.MimeTypeId);

            this.HasOptional(t => t.MediaCorrespondence)
                .WithMany(t => t.MediaCorrespondenceContexts)
                .HasForeignKey(d => d.MediaCorrespondenceId);


        }
    }
}
