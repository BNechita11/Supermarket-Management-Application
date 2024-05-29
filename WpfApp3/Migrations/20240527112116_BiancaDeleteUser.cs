using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class BiancaDeleteUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var procedure = @"
                CREATE PROCEDURE [dbo].[BiancaDeleteUser]
                    @UtilizatorId INT
                AS
                BEGIN
                    UPDATE Utilizator
                    SET IsActive = 0
                    WHERE UtilizatorId = @UtilizatorId;
                END;
            ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS [dbo].[BiancaDeleteUser];");
        }
    }
}
