using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FQ24L007B.CrowdFunding.Domain.Configurations
{
    internal class UtilisateurConfig : IEntityTypeConfiguration<Utilisateur>
    {
        public void Configure(EntityTypeBuilder<Utilisateur> builder)
        {
            builder.ToTable("Utilisateur");

            builder.Property(u => u.Nom)
                .HasColumnType("NVARCHAR(75)");

            builder.Property(u => u.Email)
                .HasColumnType("NVARCHAR(384)");
        }
    }
}
