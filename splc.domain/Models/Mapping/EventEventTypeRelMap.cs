using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class EventEventTypeRelMap : EntityTypeConfiguration<EventEventTypeRel>
    {
        public EventEventTypeRelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("EventEventTypeRel", "Beholder");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EventId).HasColumnName("EventId");
            this.Property(t => t.EventTypeId).HasColumnName("EventTypeId");

            // Relationships
            this.HasRequired(t => t.Event)
                .WithMany(t => t.EventEventTypeRels)
                .HasForeignKey(d => d.EventId);
            this.HasRequired(t => t.EventType)
                .WithMany(t => t.EventEventTypeRels)
                .HasForeignKey(d => d.EventTypeId);

        }
    }
}
