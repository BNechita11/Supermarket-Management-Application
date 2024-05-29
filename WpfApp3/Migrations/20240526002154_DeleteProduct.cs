
using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class DeleteProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
                CREATE PROCEDURE [dbo].[DeleteProduct]
                    @ProdusId INT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    UPDATE Produs
                    SET IsActive = 0
                    WHERE ProdusId = @ProdusId;
                END
            ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[DeleteProduct]");
        }
    }
}
