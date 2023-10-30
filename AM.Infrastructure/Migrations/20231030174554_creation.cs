using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistes",
                columns: table => new
                {
                    ArtisteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contact = table.Column<string>(type: "varchar(50)", nullable: true),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nationalite = table.Column<string>(type: "varchar(50)", nullable: true),
                    Nom = table.Column<string>(type: "varchar(50)", nullable: true),
                    Prenom = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistes", x => x.ArtisteId);
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    FestivalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    Label = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ville = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.FestivalId);
                });

            migrationBuilder.CreateTable(
                name: "Chansons",
                columns: table => new
                {
                    ChansonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    StyleMusical = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: true),
                    VuesYoutube = table.Column<int>(type: "int", nullable: false),
                    ArtisteFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chansons", x => x.ChansonId);
                    table.ForeignKey(
                        name: "FK_Chansons_Artistes_ArtisteFk",
                        column: x => x.ArtisteFk,
                        principalTable: "Artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    DateConcert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtisteFk = table.Column<int>(type: "int", nullable: false),
                    FestivalFk = table.Column<int>(type: "int", nullable: false),
                    Cachet = table.Column<double>(type: "float", nullable: false),
                    Duree = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => new { x.ArtisteFk, x.FestivalFk, x.DateConcert });
                    table.ForeignKey(
                        name: "FK_Concerts_Artistes_ArtisteFk",
                        column: x => x.ArtisteFk,
                        principalTable: "Artistes",
                        principalColumn: "ArtisteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Concerts_Festivals_FestivalFk",
                        column: x => x.FestivalFk,
                        principalTable: "Festivals",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chansons_ArtisteFk",
                table: "Chansons",
                column: "ArtisteFk");

            migrationBuilder.CreateIndex(
                name: "IX_Concerts_FestivalFk",
                table: "Concerts",
                column: "FestivalFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chansons");

            migrationBuilder.DropTable(
                name: "Concerts");

            migrationBuilder.DropTable(
                name: "Artistes");

            migrationBuilder.DropTable(
                name: "Festivals");
        }
    }
}
