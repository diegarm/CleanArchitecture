using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean.Infrastructure.Data.Migrations
{
    public partial class teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("131ae245-1d9d-4f6d-a2fa-a6267eafbd06"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("f7fa39c7-24d5-4cb7-9fcb-4e97bddf79f1"));

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "Gender", "LastName", "Name" },
                values: new object[] { new Guid("a5ffb103-2841-49ff-aa29-2209a38828bf"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", 0, "de Arruda Bento", "Diego Armando" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "Gender", "LastName", "Name" },
                values: new object[] { new Guid("337fc243-911c-4b78-96ab-b06ce0abd801"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", 0, "de Arruda Bento", "Diego Armando" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("337fc243-911c-4b78-96ab-b06ce0abd801"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("a5ffb103-2841-49ff-aa29-2209a38828bf"));

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Person");

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "LastName", "Name" },
                values: new object[] { new Guid("131ae245-1d9d-4f6d-a2fa-a6267eafbd06"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", "de Arruda Bento", "Diego Armando" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "LastName", "Name" },
                values: new object[] { new Guid("f7fa39c7-24d5-4cb7-9fcb-4e97bddf79f1"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", "de Arruda Bento", "Diego Armando" });
        }
    }
}
