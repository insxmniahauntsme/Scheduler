using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Scheduler.Data.Models;
using TaskStatus = Scheduler.Data.Models.TaskStatus;

#nullable disable

namespace Scheduler.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:task_priority", "high,medium,low")
                .Annotation("Npgsql:Enum:task_status", "planned,in_progress,completed,postponed,overdue");

            migrationBuilder.CreateTable(
                name: "tasks",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    description = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    start_at = table.Column<DateTime>(type: "timestamptz", nullable: false),
                    duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    status = table.Column<TaskStatus>(type: "task_status", nullable: false),
                    priority = table.Column<TaskPriority>(type: "task_priority", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks", x => x.id);
                    table.ForeignKey(
                        name: "FK_tasks_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_start_at",
                table: "tasks",
                column: "start_at");

            migrationBuilder.CreateIndex(
                name: "IX_tasks_user_id",
                table: "tasks",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:task_priority", "high,medium,low")
                .OldAnnotation("Npgsql:Enum:task_status", "planned,in_progress,completed,postponed,overdue");
        }
    }
}
