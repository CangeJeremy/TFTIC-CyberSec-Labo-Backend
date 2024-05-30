using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FQ24L007B.CrowdFunding.Domain.Configuration
{
    internal class ParticipationConfig : IEntityTypeConfiguration<Participation>
    {
        public void Configure(EntityTypeBuilder<Participation> builder)
        {
            builder.ToTable("Participation");

            builder.Property(p => p.Date)
                .HasDefaultValueSql("SYSDATETIME()")
                .ValueGeneratedOnAdd();

            builder.HasOne(p => p.Utilisateur)
                .WithMany(u => u.Participations)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Contrepartie)
                .WithMany(c => c.Participations)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
