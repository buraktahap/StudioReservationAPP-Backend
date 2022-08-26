using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioReservationAPP.Migrations
{
    public partial class waiting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaitingQueues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WaitingQueues",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    QueueEnrollTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitingQueues", x => new { x.MemberId, x.LessonId });
                    table.ForeignKey(
                        name: "FK_WaitingQueues_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WaitingQueues_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaitingQueues_LessonId",
                table: "WaitingQueues",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_WaitingQueues_MemberId",
                table: "WaitingQueues",
                column: "MemberId",
                unique: true);
        }
    }
}
