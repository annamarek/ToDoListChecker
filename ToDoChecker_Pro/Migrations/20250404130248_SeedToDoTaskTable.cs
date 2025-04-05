using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoChecker_Pro.Migrations
{
    /// <inheritdoc />
    public partial class SeedToDoTaskTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDoTasks",
                columns: new[] { "Id", "IsDone", "Name" },
                values: new object[,]
                {
                    { 1, false, "Go to the gym" },
                    { 2, false, "Visit cosmetologist" },
                    { 3, false, "Cook dinner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ToDoTasks",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
