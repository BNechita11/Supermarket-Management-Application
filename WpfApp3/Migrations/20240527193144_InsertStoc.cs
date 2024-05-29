using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp3.Migrations
{
    /// <inheritdoc />
    public partial class InsertStoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"
                CREATE PROCEDURE InsertStoc
                    @ProdusId INT,
                    @Cantitate DECIMAL(18, 2),
                    @UnitateDeMasura NVARCHAR(MAX),
                    @DataAprovizionarii DATETIME,
                    @DataExpirarii DATETIME,
                    @PretAchizitie DECIMAL(18, 2),
                    @IsActive BIT
                AS
                BEGIN
                    DECLARE @PretVanzare DECIMAL(18, 2);
                    SET @PretVanzare = @PretAchizitie * 1.10;
                    
                    INSERT INTO Stoc (ProdusId, Cantitate, UnitateDeMasura, DataAprovizionarii, DataExpirarii, PretAchizitie, PretVanzare, IsActive)
                    VALUES (@ProdusId, @Cantitate, @UnitateDeMasura, @DataAprovizionarii, @DataExpirarii, @PretAchizitie, @PretVanzare, @IsActive)
                END
            ";

            migrationBuilder.Sql(procedure);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP PROCEDURE IF EXISTS InsertStoc
            ");
        }
    }
}
