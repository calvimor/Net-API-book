using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nexos.CAVM.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CityFrom = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublisherName = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublisherEmail = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    MaxNumberBook = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberPages = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PublisherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Birthday", "CityFrom", "CreatedTime", "Email", "LastUpdatedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTime(1950, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mendoza, AR", new DateTime(1950, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "pablo.m@email.com", new DateTime(2021, 6, 14, 22, 54, 15, 252, DateTimeKind.Local).AddTicks(8991), "Pablo Muñoz" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new DateTime(1927, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aracataca, CO", new DateTime(1950, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2021, 6, 14, 22, 54, 15, 256, DateTimeKind.Local).AddTicks(7463), "Gabriel Garcia Marquez" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "CreatedTime", "LastUpdatedTime", "MaxNumberBook", "PublisherEmail", "PublisherName", "Telephone" },
                values: new object[,]
                {
                    { new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Canadá", new DateTime(2021, 6, 14, 22, 54, 15, 259, DateTimeKind.Local).AddTicks(6963), new DateTime(2021, 6, 14, 22, 54, 15, 259, DateTimeKind.Local).AddTicks(6982), 3, "editorial@metanoia.com", "Metanoia Press", "3158889987" },
                    { new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Argentina", new DateTime(2021, 6, 14, 22, 54, 15, 259, DateTimeKind.Local).AddTicks(7007), new DateTime(2021, 6, 14, 22, 54, 15, 259, DateTimeKind.Local).AddTicks(7009), -1, "editorial@sudamericana.com", "Sudamericana", "3150009987" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedTime", "Genre", "LastUpdatedTime", "NumberPages", "PublisherId", "Title", "Year" },
                values: new object[] { new Guid("40ff5488-fdab-45b5-bc3a-14302d59869a"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTime(2021, 6, 14, 22, 54, 15, 260, DateTimeKind.Local).AddTicks(2538), "Actualidad", new DateTime(2021, 6, 14, 22, 54, 15, 260, DateTimeKind.Local).AddTicks(2550), 250, new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "Las mentiras que te cuentan, las verdades que te ocultan", 2021 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CreatedTime", "Genre", "LastUpdatedTime", "NumberPages", "PublisherId", "Title", "Year" },
                values: new object[] { new Guid("d173e20d-159e-9907-9ce9-b0ac2564ad97"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new DateTime(2021, 6, 14, 22, 54, 15, 260, DateTimeKind.Local).AddTicks(2578), "Novela", new DateTime(2021, 6, 14, 22, 54, 15, 260, DateTimeKind.Local).AddTicks(2580), 471, new Guid("102b566b-ba1f-404c-b2df-e2cde39ade09"), "Cien años de soledad", 1967 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
