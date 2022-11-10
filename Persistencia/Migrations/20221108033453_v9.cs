using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "video",
                table: "Cabeceras");

            migrationBuilder.DropColumn(
                name: "videoBase64",
                table: "Cabeceras");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "video",
                table: "Cabeceras",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "videoBase64",
                table: "Cabeceras",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
