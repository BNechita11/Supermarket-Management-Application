
using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class BiaInsertUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedureText =
                @"CREATE PROCEDURE BiaInsertUser
                      @Nume NVARCHAR(100),
                      @Parola NVARCHAR(100),
                      @TipUtilizator NVARCHAR(50),
                      @IsActive BIT
                  AS
                  BEGIN
                      INSERT INTO Utilizator (Nume, Parola, TipUtilizator, IsActive)
                      VALUES (@Nume, @Parola, @TipUtilizator, @IsActive);

                      SELECT SCOPE_IDENTITY() AS UtilizatorId;
                  END;";

            migrationBuilder.Sql(procedureText);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS InsertUser");
        }
    }
}
