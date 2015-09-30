using System.Data.Entity.ModelConfiguration;

namespace splc.domain.Models.Mapping
{
    public class StateMap : EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.StateCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(2);

            this.Property(t => t.StateName)
                .IsRequired()
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("State", "Common");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StateCode).HasColumnName("StateCode");
            this.Property(t => t.StateName).HasColumnName("StateName");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CreatedUserId).HasColumnName("CreatedUserId");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.ModifiedUserId).HasColumnName("ModifiedUserId");

            // Relationships
            this.HasRequired(t => t.CreatedUser)
                .WithMany(t => t.StatesCreated)
                .HasForeignKey(d => d.CreatedUserId);
            this.HasOptional(t => t.ModifiedUser)
                .WithMany(t => t.StatesModified)
                .HasForeignKey(d => d.ModifiedUserId);

        }
    }
}
