using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaWebsiteEGroupContextMap : EntityTypeConfiguration<MediaWebsiteEGroupContext>
    {
        public MediaWebsiteEGroupContextMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

    //        this.MapToStoredProcedures(s =>
    //s.Insert(i => i.HasName("Beholder.p_addMediaPublishedContext"))
    // .Update(u => u.HasName("Beholder.p_updMediaPublishedContext")));

            // Properties
            // Table & Column Mappings
            this.ToTable("MediaWebsiteEGroupContext", "Beholder");

            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.MimeTypeId).HasColumnName("MimeTypeId");
            this.Property(t => t.DocumentExtension).HasColumnName("DocumentExtension");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.ContextText).HasColumnName("ContextText");

            // Relationships
            this.HasOptional(t => t.MimeType)
                .WithMany(t => t.MediaWebsiteEGroupContexts)
                .HasForeignKey(d => d.MimeTypeId);

            
            this.HasOptional(t => t.MediaWebsiteEGroup)
                .WithMany(t => t.MediaWebsiteEGroupContexts)
                .HasForeignKey(d => d.MediaWebsiteEGroupId);

            //this.HasRequired(t => t.MediaPublishedContext_Index)
            //    .WithRequiredPrincipal();
        }
    }
}
