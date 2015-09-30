using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class MediaPublishedContext_IndexMap : EntityTypeConfiguration<MediaPublishedContext_Index>
    {
        public MediaPublishedContext_IndexMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("v_MediaPublishedContext", "Beholder");

            this.Property(t => t.Id).HasColumnName("Id");
            //this.Property(t => t.MimeTypeId).HasColumnName("MimeTypeId");
            //this.Property(t => t.DocumentExtension).HasColumnName("DocumentExtension");
            //this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.ContextText).HasColumnName("ContextText");

            this.Property(t => t.MediaPublishedId).HasColumnName("MediaPublishedId");

            this.HasOptional(t => t.MediaPublished)
                .WithMany(t => t.MediaPublishedContext_Indexes)
                .HasForeignKey(d => d.MediaPublishedId);


        }
    }
}
