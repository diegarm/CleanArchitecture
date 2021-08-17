using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean.Infrastructure.Data.Migrations
{
    public partial class teste : Migration
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
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "LastName", "Name" },
                values: new object[] { new Guid("131ae245-1d9d-4f6d-a2fa-a6267eafbd06"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", "de Arruda Bento", "Diego Armando" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "LastName", "Name" },
                values: new object[] { new Guid("f7fa39c7-24d5-4cb7-9fcb-4e97bddf79f1"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", "de Arruda Bento", "Diego Armando" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
