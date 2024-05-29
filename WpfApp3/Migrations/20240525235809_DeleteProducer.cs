using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class DeleteProducer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"
                CREATE PROCEDURE [dbo].[DeleteProducer]
                    @ProducatorId INT
                AS
                BEGIN
                    SET NOCOUNT ON;
                    UPDATE Stoc
                    SET IsActive = 0
                    WHERE ProducatorId = @ProducatorId;
                END
            ";

            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[DeleteProducer]");
        }
    }
}
