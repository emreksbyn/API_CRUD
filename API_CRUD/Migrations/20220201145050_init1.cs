using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_CRUD.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Description", "Name", "Slug", "Status", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 1, 17, 50, 47, 570, DateTimeKind.Local).AddTicks(9318), null, "Size yakışan tüm ürünler.", "Giyim", "giyim", 1, null },
                    { 2, new DateTime(2022, 2, 1, 17, 50, 47, 634, DateTimeKind.Local).AddTicks(9189), null, "Hem şık, hem ucuz.", "Aksesuar", "aksesuar", 1, null },
                    { 3, new DateTime(2022, 2, 1, 17, 50, 47, 634, DateTimeKind.Local).AddTicks(9266), null, "Hem konforlu, hem şık, hem ucuz.", "Ayakkabı", "ayakkabı", 1, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Password", "Status", "UpdateDate", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 1, 17, 50, 47, 640, DateTimeKind.Local).AddTicks(223), null, "123", 1, null, "Emre" },
                    { 2, new DateTime(2022, 2, 1, 17, 50, 47, 640, DateTimeKind.Local).AddTicks(2929), null, "123", 1, null, "Erkan" },
                    { 3, new DateTime(2022, 2, 1, 17, 50, 47, 640, DateTimeKind.Local).AddTicks(2956), null, "123", 1, null, "Erol" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
