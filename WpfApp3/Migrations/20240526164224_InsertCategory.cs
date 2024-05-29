using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class InsertCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedureText =
                @"CREATE PROCEDURE InsertCategory
                      @Nume NVARCHAR(100),
                      @IsActive BIT
                  AS
                  BEGIN
                      INSERT INTO Categorie (Nume, IsActive)
                      VALUES (@Nume, @IsActive);
                  END;";

            migrationBuilder.Sql(procedureText);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS InsertCategorie");
        }
    }
}
