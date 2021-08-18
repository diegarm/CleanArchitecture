using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean.Infrastructure.Data.Migrations
{
    public partial class teste1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FiscalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "Gender", "LastName", "Name" },
                values: new object[] { new Guid("22b6a394-b292-436a-9157-6f651e6cb799"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", 1, "de Arruda Bento", "Diego Armando" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "Gender", "LastName", "Name" },
                values: new object[] { new Guid("40ccc2d2-9d4a-4182-9553-eaf04d62af6f"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", 1, "de Arruda Bento", "Diego Armando" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
