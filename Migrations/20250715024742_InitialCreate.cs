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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Author", "Content", "CreatedAt", "Title" },
                values: new object[,]
                {
                    { 1, "Admin", "게시판이 열렸습니다!", new DateTime(2025, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "첫 번째 공지사항" },
                    { 2, "Gildong", "처음으로 글을 남깁니다.", new DateTime(2025, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "안녕하세요!" },
                    { 3, "Chunhyang", "Blazor는 어떻게 사용하나요?", new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "질문 있습니다." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
