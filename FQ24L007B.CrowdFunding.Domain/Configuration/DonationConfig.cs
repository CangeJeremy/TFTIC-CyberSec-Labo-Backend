using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FQ24L007B.CrowdFunding.Domain.Configuration
{
    internal class DonationConfig : IEntityTypeConfiguration<Donation>
    {
        public void Configure(EntityTypeBuilder<Donation> builder)
        {
            builder.ToTable("Donation", table =>
            {
                table.HasCheckConstraint("CK_Donation_Montant", "Montant > 0");
            });

            builder.Property(d => d.Date)
                .HasDefaultValueSql("SYSDATETIME()")
                .ValueGeneratedOnAdd();

            builder.HasOne(d => d.Utilisateur)
                .WithMany(u => u.Donations)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.Projet)
                .WithMany(p => p.Donations)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
