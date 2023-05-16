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
                name: "Administratori",
                columns: table => new
                {
                    KorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImeIPrezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SlikaKorisnika = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administratori", x => x.KorisnickoIme);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ImeAdministratora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImeIPrezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SlikaKorisnika = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KorisnickoIme);
                    table.ForeignKey(
                        name: "FK_Kupac_Administratori_KorisnickoIme",
                        column: x => x.KorisnickoIme,
                        principalTable: "Administratori",
                        principalColumn: "KorisnickoIme");
                });

            migrationBuilder.CreateTable(
                name: "Prodavci",
                columns: table => new
                {
                    KorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Verifikovan = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AdministratorKorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImeAdministratora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImeIPrezime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SlikaKorisnika = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavci", x => x.KorisnickoIme);
                    table.ForeignKey(
                        name: "FK_Prodavci_Administratori_AdministratorKorisnickoIme",
                        column: x => x.AdministratorKorisnickoIme,
                        principalTable: "Administratori",
                        principalColumn: "KorisnickoIme");
                });

            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    IDArtikla = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlikaArtikla = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    KorisnickoImeProdavca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Obrisan = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.IDArtikla);
                    table.ForeignKey(
                        name: "FK_Artikal_Prodavci_KorisnickoImeProdavca",
                        column: x => x.KorisnickoImeProdavca,
                        principalTable: "Prodavci",
                        principalColumn: "KorisnickoIme",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Porudzbina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Komentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VremePorudzbine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeDostave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnickoImeKupca = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProdavacKorisnickoIme = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porudzbina_Kupac_KorisnickoImeKupca",
                        column: x => x.KorisnickoImeKupca,
                        principalTable: "Kupac",
                        principalColumn: "KorisnickoIme");
                    table.ForeignKey(
                        name: "FK_Porudzbina_Prodavci_ProdavacKorisnickoIme",
                        column: x => x.ProdavacKorisnickoIme,
                        principalTable: "Prodavci",
                        principalColumn: "KorisnickoIme");
                });

            migrationBuilder.CreateTable(
                name: "PorudzbinaArtikli",
                columns: table => new
                {
                    IdPorudzbine = table.Column<int>(type: "int", nullable: false),
                    IdArtikla = table.Column<int>(type: "int", nullable: false),
                    PorudzbinaId = table.Column<int>(type: "int", nullable: false),
                    KolicinaArtikla = table.Column<int>(type: "int", nullable: false),
                    UkupnaCenaArtikala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PorudzbinaArtikli", x => new { x.IdPorudzbine, x.IdArtikla });
                    table.ForeignKey(
                        name: "FK_PorudzbinaArtikli_Artikal_IdArtikla",
                        column: x => x.IdArtikla,
                        principalTable: "Artikal",
                        principalColumn: "IDArtikla");
                    table.ForeignKey(
                        name: "FK_PorudzbinaArtikli_Porudzbina_PorudzbinaId",
                        column: x => x.PorudzbinaId,
                        principalTable: "Porudzbina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administratori_KorisnickoIme",
                table: "Administratori",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_KorisnickoImeProdavca",
                table: "Artikal",
                column: "KorisnickoImeProdavca");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnickoIme",
                table: "Kupac",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbina_KorisnickoImeKupca",
                table: "Porudzbina",
                column: "KorisnickoImeKupca");

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbina_ProdavacKorisnickoIme",
                table: "Porudzbina",
                column: "ProdavacKorisnickoIme");

            migrationBuilder.CreateIndex(
                name: "IX_PorudzbinaArtikli_IdArtikla",
                table: "PorudzbinaArtikli",
                column: "IdArtikla");

            migrationBuilder.CreateIndex(
                name: "IX_PorudzbinaArtikli_PorudzbinaId",
                table: "PorudzbinaArtikli",
                column: "PorudzbinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavci_AdministratorKorisnickoIme",
                table: "Prodavci",
                column: "AdministratorKorisnickoIme");

            migrationBuilder.CreateIndex(
                name: "IX_Prodavci_KorisnickoIme",
                table: "Prodavci",
                column: "KorisnickoIme",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PorudzbinaArtikli");

            migrationBuilder.DropTable(
                name: "Artikal");

            migrationBuilder.DropTable(
                name: "Porudzbina");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Prodavci");

            migrationBuilder.DropTable(
                name: "Administratori");
        }
    }
}
