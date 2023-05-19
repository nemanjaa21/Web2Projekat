using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    IdKorisnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipKorisnika = table.Column<int>(type: "int", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImeIPrezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaKorisnika = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Verifikovan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.IdKorisnika);
                });

            migrationBuilder.CreateTable(
                name: "Artikli",
                columns: table => new
                {
                    IdArtikla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivArtikla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CenaArtikla = table.Column<int>(type: "int", nullable: false),
                    SlikaArtikla = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKorisnika = table.Column<int>(type: "int", nullable: false),
                    Obrisan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikli", x => x.IdArtikla);
                    table.ForeignKey(
                        name: "FK_Artikli_Korisnici_IdKorisnika",
                        column: x => x.IdKorisnika,
                        principalTable: "Korisnici",
                        principalColumn: "IdKorisnika",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Porudzbine",
                columns: table => new
                {
                    IdPorudzbine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VremePorudzbine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeDostave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CenaPorudzbine = table.Column<double>(type: "float", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKorisnika = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbine", x => x.IdPorudzbine);
                    table.ForeignKey(
                        name: "FK_Porudzbine_Korisnici_IdKorisnika",
                        column: x => x.IdKorisnika,
                        principalTable: "Korisnici",
                        principalColumn: "IdKorisnika");
                });

            migrationBuilder.CreateTable(
                name: "PorudzbineArtikli",
                columns: table => new
                {
                    IdPorudzbine = table.Column<int>(type: "int", nullable: false),
                    IdArtikla = table.Column<int>(type: "int", nullable: false),
                    KolicinaArtikla = table.Column<int>(type: "int", nullable: false),
                    UkupnaCenaArtikala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PorudzbineArtikli", x => new { x.IdPorudzbine, x.IdArtikla });
                    table.ForeignKey(
                        name: "FK_PorudzbineArtikli_Artikli_IdArtikla",
                        column: x => x.IdArtikla,
                        principalTable: "Artikli",
                        principalColumn: "IdArtikla");
                    table.ForeignKey(
                        name: "FK_PorudzbineArtikli_Porudzbine_IdPorudzbine",
                        column: x => x.IdPorudzbine,
                        principalTable: "Porudzbine",
                        principalColumn: "IdPorudzbine");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikli_IdKorisnika",
                table: "Artikli",
                column: "IdKorisnika");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_KorisnickoIme",
                table: "Korisnici",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbine_IdKorisnika",
                table: "Porudzbine",
                column: "IdKorisnika");

            migrationBuilder.CreateIndex(
                name: "IX_PorudzbineArtikli_IdArtikla",
                table: "PorudzbineArtikli",
                column: "IdArtikla");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PorudzbineArtikli");

            migrationBuilder.DropTable(
                name: "Artikli");

            migrationBuilder.DropTable(
                name: "Porudzbine");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
