using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageSkill");

            migrationBuilder.AddColumn<string>(
                name: "ImageSkills",
                table: "Habilidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "imageByte",
                table: "Habilidades",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageSkills",
                table: "Habilidades");

            migrationBuilder.DropColumn(
                name: "imageByte",
                table: "Habilidades");

            migrationBuilder.CreateTable(
                name: "ImageSkill",
                columns: table => new
                {
                    imageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Base64Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSkill = table.Column<int>(type: "int", nullable: false),
                    imageContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageSkill", x => x.imageId);
                    table.ForeignKey(
                        name: "FK_ImageSkill_Habilidades_IdSkill",
                        column: x => x.IdSkill,
                        principalTable: "Habilidades",
                        principalColumn: "IdSkill",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageSkill_IdSkill",
                table: "ImageSkill",
                column: "IdSkill");
        }
    }
}
