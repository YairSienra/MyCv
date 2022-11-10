using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageSkill_IdSkill",
                table: "ImageSkill");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSkill_IdSkill",
                table: "ImageSkill",
                column: "IdSkill");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ImageSkill_IdSkill",
                table: "ImageSkill");

            migrationBuilder.CreateIndex(
                name: "IX_ImageSkill_IdSkill",
                table: "ImageSkill",
                column: "IdSkill",
                unique: true);
        }
    }
}
