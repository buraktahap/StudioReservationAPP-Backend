using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioReservationAPP.Migrations
{
    public partial class waitingqueuefinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WaitingQueues_MemberId",
                table: "WaitingQueues");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingQueues_MemberId",
                table: "WaitingQueues",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WaitingQueues_MemberId",
                table: "WaitingQueues");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingQueues_MemberId",
                table: "WaitingQueues",
                column: "MemberId",
                unique: true,
                filter: "[MemberId] IS NOT NULL");
        }
    }
}
