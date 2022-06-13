using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptApi.Migrations
{
    public partial class AddPetNeedSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Needs",
                columns: new[] { "Id", "DeletedOn", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, null, true, "Deficiência visual" },
                    { 2, null, true, "Deficiência auditiva" },
                    { 3, null, true, "Deficiência motora" },
                    { 4, null, true, "Doenças transmissíveis" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Needs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Needs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Needs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Needs",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
