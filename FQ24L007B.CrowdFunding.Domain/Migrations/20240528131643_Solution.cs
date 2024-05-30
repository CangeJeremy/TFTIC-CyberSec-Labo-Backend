using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FQ24L007B.CrowdFunding.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Solution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "NVARCHAR(75)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(384)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "NVARCHAR(255)", nullable: false),
                    Objectif = table.Column<int>(type: "int", nullable: false),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.Id);
                    table.CheckConstraint("CK_Projet_Objectif", "Objectif >= 1000");
                    table.ForeignKey(
                        name: "FK_Projet_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contrepartie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(1000)", nullable: false),
                    Montant = table.Column<int>(type: "int", nullable: false),
                    ProjetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrepartie", x => x.Id);
                    table.CheckConstraint("CK_Contrepartie", "Montant > 0");
                    table.ForeignKey(
                        name: "FK_Contrepartie_Projet_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projet",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    ProjetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                    table.CheckConstraint("CK_Donation_Montant", "Montant > 0");
                    table.ForeignKey(
                        name: "FK_Donation_Projet_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Donation_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    UtilisateurId = table.Column<int>(type: "int", nullable: false),
                    ContrepartieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participation_Contrepartie_ContrepartieId",
                        column: x => x.ContrepartieId,
                        principalTable: "Contrepartie",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participation_Utilisateur_UtilisateurId",
                        column: x => x.UtilisateurId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrepartie_ProjetId",
                table: "Contrepartie",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_ProjetId",
                table: "Donation",
                column: "ProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_UtilisateurId",
                table: "Donation",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_ContrepartieId",
                table: "Participation",
                column: "ContrepartieId");

            migrationBuilder.CreateIndex(
                name: "IX_Participation_UtilisateurId",
                table: "Participation",
                column: "UtilisateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Projet_UtilisateurId",
                table: "Projet",
                column: "UtilisateurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropTable(
                name: "Participation");

            migrationBuilder.DropTable(
                name: "Contrepartie");

            migrationBuilder.DropTable(
                name: "Projet");

            migrationBuilder.DropTable(
                name: "Utilisateur");
        }
    }
}
