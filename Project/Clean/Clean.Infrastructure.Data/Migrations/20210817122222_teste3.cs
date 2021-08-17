using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean.Infrastructure.Data.Migrations
{
    public partial class teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("337fc243-911c-4b78-96ab-b06ce0abd801"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("a5ffb103-2841-49ff-aa29-2209a38828bf"));

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "Gender", "LastName", "Name" },
                values: new object[] { new Guid("728a345e-a34f-40e5-8250-08c3563f5c57"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", 1, "de Arruda Bento", "Diego Armando" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "Gender", "LastName", "Name" },
                values: new object[] { new Guid("706e53ee-8799-4aa7-95ed-d5af7f9b790c"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", 1, "de Arruda Bento", "Diego Armando" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("706e53ee-8799-4aa7-95ed-d5af7f9b790c"));

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: new Guid("728a345e-a34f-40e5-8250-08c3563f5c57"));

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "Gender", "LastName", "Name" },
                values: new object[] { new Guid("a5ffb103-2841-49ff-aa29-2209a38828bf"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", 0, "de Arruda Bento", "Diego Armando" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "BirthDay", "FirstName", "FiscalNumber", "Gender", "LastName", "Name" },
                values: new object[] { new Guid("337fc243-911c-4b78-96ab-b06ce0abd801"), new DateTime(1986, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diego Armando", "34801267823", 0, "de Arruda Bento", "Diego Armando" });
        }
    }
}
