using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfApp3.Migrations
{
    public partial class UpdateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedureText = @"
                CREATE PROCEDURE UpdateUser
                    @UtilizatorId INT,
                    @Nume NVARCHAR(100),
                    @Parola NVARCHAR(100),
                    @TipUtilizator NVARCHAR(50),
                    @IsActive BIT
                AS
                BEGIN
                    UPDATE Utilizator
                    SET Nume = @Nume, Parola = @Parola, TipUtilizator = @TipUtilizator, IsActive = @IsActive
                    WHERE UtilizatorId = @UtilizatorId;
                END;
            ";

            migrationBuilder.Sql(procedureText);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS UpdateUser");
        }
    }
}
