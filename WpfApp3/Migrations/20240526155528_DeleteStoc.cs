using Microsoft.EntityFrameworkCore.Migrations;

namespace WpfApp3.Migrations
{
    public partial class DeleteStoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Aplică procedura stocată pentru ștergerea logică a înregistrării de stoc
            migrationBuilder.Sql(
                @"CREATE PROCEDURE DeleteStoc
                      @StocId INT
                  AS
                  BEGIN
                      UPDATE Stoc
                      SET IsActive = 0
                      WHERE StocId = @StocId;

                      SELECT 'Înregistrarea de stoc a fost ștearsă logic.' AS ResultMessage;
                  END;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Înlătură procedura stocată dacă migrarea este anulată
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS DeleteStoc");
        }
    }
}
