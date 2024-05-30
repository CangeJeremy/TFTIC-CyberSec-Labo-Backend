using FQ24L007B.CrowdFunding.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FQ24L007B.CrowdFunding.Domain.Configurations
{
    internal class ProjetConfig : IEntityTypeConfiguration<Projet>
    {
        public void Configure(EntityTypeBuilder<Projet> builder)
        {
            builder.ToTable("Projet", table =>
            {
                table.HasCheckConstraint("CK_Projet_Objectif", "Objectif >= 1000");
            });

            builder.Property(p => p.Nom)
                .HasColumnType("NVARCHAR(255)");

            builder.HasOne(p => p.Utilisateur)
                .WithMany(u => u.Projets)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
