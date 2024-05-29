using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class GetBiggestBon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"
                CREATE PROCEDURE GetBiggestBon
                    @DataSelectata DATE
                AS
                BEGIN
                    SELECT TOP 1 * 
                    FROM BonCasa 
                    WHERE CONVERT(DATE, DataEliberarii) = @DataSelectata
                    ORDER BY SumaIncasata DESC
                END
            ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE GetBiggestBon");
        }
    }
}
