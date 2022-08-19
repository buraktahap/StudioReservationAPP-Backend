using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioReservationAPP.Migrations
{
    public partial class attributeRenamingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quota",
                table: "Lessons",
                newName: "WaitingQueueQuota");

            migrationBuilder.AddColumn<int>(
                name: "EnrollQuota",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnrollQuota",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "WaitingQueueQuota",
                table: "Lessons",
                newName: "Quota");
        }
    }
}
