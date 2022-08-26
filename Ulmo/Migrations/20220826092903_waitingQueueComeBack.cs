using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioReservationAPP.Migrations
{
    public partial class waitingQueueComeBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaitingQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueueEnrollTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    LessonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingQueues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaitingQueues_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WaitingQueues_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaitingQueues_LessonId",
                table: "WaitingQueues",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingQueues_MemberId",
                table: "WaitingQueues",
                column: "MemberId",
                unique: true,
                filter: "[MemberId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaitingQueues");
        }
    }
}
