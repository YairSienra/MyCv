using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

           

            migrationBuilder.CreateTable(
                name: "ImageSkill",
                columns: table => new
                {
                    imageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IdSkill = table.Column<int>(type: "int", nullable: false)
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
                column: "IdSkill",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "ImageSkill");

         
        }
    }
}
