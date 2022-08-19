using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioReservationAPP.Migrations
{
    public partial class waitingQueueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Enrollments_MemberLessonMemberId_MemberLessonLessonId",
                table: "Enrollments");

            migrationBuilder.DropIndex(
                name: "IX_Enrollments_MemberLessonMemberId_MemberLessonLessonId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "AverageRate",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "EnrollCount",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "MemberLessonLessonId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "MemberLessonMemberId",
                table: "Enrollments");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Enrollments");

            migrationBuilder.RenameColumn(
                name: "isEnrolled",
                table: "Enrollments",
                newName: "IsEnrolled");

            migrationBuilder.RenameColumn(
                name: "isCompleted",
                table: "Enrollments",
                newName: "IsCompleted");

            migrationBuilder.RenameColumn(
                name: "isCheckin",
                table: "Enrollments",
                newName: "IsCheckin");

            migrationBuilder.AddColumn<int>(
                name: "EnrollCount",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WaitingQueueCount",
                table: "Lessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCheckin",
                table: "Enrollments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaitingQueues");

            migrationBuilder.DropColumn(
                name: "EnrollCount",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "WaitingQueueCount",
                table: "Lessons");

            migrationBuilder.RenameColumn(
                name: "IsEnrolled",
                table: "Enrollments",
                newName: "isEnrolled");

            migrationBuilder.RenameColumn(
                name: "IsCompleted",
                table: "Enrollments",
                newName: "isCompleted");

            migrationBuilder.RenameColumn(
                name: "IsCheckin",
                table: "Enrollments",
                newName: "isCheckin");

            migrationBuilder.AddColumn<double>(
                name: "AverageRate",
                table: "Lessons",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<bool>(
                name: "isCompleted",
                table: "Enrollments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "isCheckin",
                table: "Enrollments",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<int>(
                name: "EnrollCount",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberLessonLessonId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MemberLessonMemberId",
                table: "Enrollments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Enrollments",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_MemberLessonMemberId_MemberLessonLessonId",
                table: "Enrollments",
                columns: new[] { "MemberLessonMemberId", "MemberLessonLessonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Enrollments_MemberLessonMemberId_MemberLessonLessonId",
                table: "Enrollments",
                columns: new[] { "MemberLessonMemberId", "MemberLessonLessonId" },
                principalTable: "Enrollments",
                principalColumns: new[] { "MemberId", "LessonId" });
        }
    }
}
