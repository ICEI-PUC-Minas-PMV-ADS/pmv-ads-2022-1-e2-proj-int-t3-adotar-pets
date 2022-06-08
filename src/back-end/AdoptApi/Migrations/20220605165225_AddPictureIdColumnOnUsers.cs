using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptApi.Migrations
{
    public partial class AddPictureIdColumnOnUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PictureId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PictureId",
                table: "Users",
                column: "PictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Pictures_PictureId",
                table: "Users",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Pictures_PictureId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PictureId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PictureId",
                table: "Users");
        }
    }
}
