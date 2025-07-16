using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorBoard.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "admin", "掲示板が開かれました！", new DateTime(2025, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "1番目", 0 },
                    { 2, "admin", "初めまして", new DateTime(2025, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "初めまして!", 0 },
                    { 3, "admin", "Blazor", new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blazor Board Site", 0 },
                    { 4, "admin", "いいですね！", new DateTime(2025, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "いい天気です", 0 },
                    { 5, "kim", "初めてですね", new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "おはようございます!", 0 },
                    { 6, "bang", "質問！", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "質問があります", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "管理者", "1234", "Admin", "admin" },
                    { 2, "方斗賢", "1234", "User", "bang" },
                    { 3, "金", "1234", "User", "kim" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
