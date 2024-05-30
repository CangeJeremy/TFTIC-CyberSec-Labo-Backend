using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FQ24L007B.CrowdFunding.Domain.Configurations
{
    internal class ContrepartieConfig : IEntityTypeConfiguration<Contrepartie>
    {
        public void Configure(EntityTypeBuilder<Contrepartie> builder)
        {
            builder.ToTable("Contrepartie", table =>
            {
                table.HasCheckConstraint("CK_Contrepartie", "Montant > 0");
            });

            builder.Property(p => p.Description)
                .HasColumnType("NVARCHAR(1000)");

            builder.HasOne<Projet>()
                .WithMany(p => p.Contreparties)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
