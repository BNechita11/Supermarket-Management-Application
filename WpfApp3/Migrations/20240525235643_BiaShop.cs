using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp3.Migrations
{
    /// <inheritdoc />
    public partial class BiaShop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CategorieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CategorieId);
                });

            migrationBuilder.CreateTable(
                name: "Stoc",
                columns: table => new
                {
                    ProducatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaraDeOrigine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ProducatorId);
                });

            migrationBuilder.CreateTable(
                name: "Utilizator",
                columns: table => new
                {
                    UtilizatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipUtilizator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizator", x => x.UtilizatorId);
                });

            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ProdusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodDeBare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PretNormal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PretRedus = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    ProducatorId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ProdusId);
                    table.ForeignKey(
                        name: "FK_Produs_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "CategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produs_Producator_ProducatorId",
                        column: x => x.ProducatorId,
                        principalTable: "Stoc",
                        principalColumn: "ProducatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonCasa",
                columns: table => new
                {
                    BonCasaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEliberarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CasierId = table.Column<int>(type: "int", nullable: false),
                    SumaIncasata = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonCasa", x => x.BonCasaId);
                    table.ForeignKey(
                        name: "FK_BonCasa_Utilizator_CasierId",
                        column: x => x.CasierId,
                        principalTable: "Utilizator",
                        principalColumn: "UtilizatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vanzare",
                columns: table => new
                {
                    VanzareId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Suma = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UtilizatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanzare", x => x.VanzareId);
                    table.ForeignKey(
                        name: "FK_Vanzare_Utilizator_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizator",
                        principalColumn: "UtilizatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stoc",
                columns: table => new
                {
                    StocId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitateDeMasura = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAprovizionarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExpirarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PretAchizitie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PretVanzare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoc", x => x.StocId);
                    table.ForeignKey(
                        name: "FK_Stoc_Produs_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produs",
                        principalColumn: "ProdusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BonCasaDetalii",
                columns: table => new
                {
                    BonCasaDetaliuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BonCasaId = table.Column<int>(type: "int", nullable: false),
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonCasaDetalii", x => x.BonCasaDetaliuId);
                    table.ForeignKey(
                        name: "FK_BonCasaDetalii_BonCasa_BonCasaId",
                        column: x => x.BonCasaId,
                        principalTable: "BonCasa",
                        principalColumn: "BonCasaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BonCasaDetalii_Produs_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produs",
                        principalColumn: "ProdusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BonCasa_CasierId",
                table: "BonCasa",
                column: "CasierId");

            migrationBuilder.CreateIndex(
                name: "IX_BonCasaDetalii_BonCasaId",
                table: "BonCasaDetalii",
                column: "BonCasaId");

            migrationBuilder.CreateIndex(
                name: "IX_BonCasaDetalii_ProdusId",
                table: "BonCasaDetalii",
                column: "ProdusId");

            migrationBuilder.CreateIndex(
                name: "IX_Produs_CategorieId",
                table: "Produs",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Produs_ProducatorId",
                table: "Produs",
                column: "ProducatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Stoc_ProdusId",
                table: "Stoc",
                column: "ProdusId");

            migrationBuilder.CreateIndex(
                name: "IX_Vanzare_UtilizatorId",
                table: "Vanzare",
                column: "UtilizatorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonCasaDetalii");

            migrationBuilder.DropTable(
                name: "Stoc");

            migrationBuilder.DropTable(
                name: "Vanzare");

            migrationBuilder.DropTable(
                name: "BonCasa");

            migrationBuilder.DropTable(
                name: "Produs");

            migrationBuilder.DropTable(
                name: "Utilizator");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Stoc");
        }
    }
}
