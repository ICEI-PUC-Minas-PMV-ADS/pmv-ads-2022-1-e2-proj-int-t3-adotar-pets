using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdoptApi.Migrations
{
    public partial class AddFormSeeder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "DeletedOn", "IsActive", "PetType", "Title" },
                values: new object[,]
                {
                    { 1, null, true, 0, "Eu moro em..." },
                    { 2, null, true, 1, "Eu moro em..." },
                    { 3, null, true, 0, "Meu tipo de residência é..." },
                    { 4, null, true, 1, "Meu tipo de residência é..." },
                    { 5, null, true, 0, "O pet ficará sozinho?" },
                    { 6, null, true, 1, "O pet ficará sozinho?" },
                    { 7, null, true, 0, "Há outros pets em casa?" },
                    { 8, null, true, 1, "Há outros pets em casa?" },
                    { 9, null, true, 0, "Em caso de viagens, há quem cuide do pet em sua ausência?" },
                    { 10, null, true, 1, "Em caso de viagens, há quem cuide do pet em sua ausência?" },
                    { 11, null, true, 0, "Está ciente/de acordo com a castração e vacinação?" },
                    { 12, null, true, 1, "Está ciente/de acordo com a castração e vacinação?" },
                    { 13, null, true, 0, "Como será a alimentação do pet?" },
                    { 14, null, true, 1, "Como será a alimentação do pet?" },
                    { 15, null, true, 0, "Você pode levar o pet para passear?" },
                    { 16, null, true, 1, "Possui caixa de transporte para o pet?" },
                    { 17, null, true, 0, "Está ciente/de acordo dos possíveis contratempos no processo de adaptação do pet?" },
                    { 18, null, true, 1, "Está ciente/de acordo dos possíveis contratempos no processo de adaptação do pet?" },
                    { 19, null, true, 0, "Está ciente/de acordo dos possíveis custos na manutenção do pet?" },
                    { 20, null, true, 1, "Está ciente/de acordo dos possíveis custos na manutenção do pet?" }
                });

            migrationBuilder.InsertData(
                table: "Alternatives",
                columns: new[] { "Id", "AdultAgePenalty", "BabyAgePenalty", "DeletedOn", "FemaleGenderPenalty", "IsActive", "LargeSizePenalty", "MaleGenderPenalty", "MediumSizePenalty", "QuestionId", "SeniorAgePenalty", "SmallSizePenalty", "Title" },
                values: new object[,]
                {
                    { 1, 0, 0, null, 0, true, 0, 0, 0, 1, 0, 0, "Imóvel próprio onde são permitidos animais de estimação." },
                    { 2, 0, 0, null, 0, true, 0, 0, 0, 1, 0, 0, "Imóvel alugado onde são permitidos animais de estimação." },
                    { 3, 0, 0, null, 50, true, 0, 50, 0, 1, 0, 0, "Imóvel próprio ou alugado, mas não sei se animais de estimação são permitidos." },
                    { 4, 0, 0, null, 0, true, 0, 0, 0, 2, 0, 0, "Imóvel próprio onde são permitidos animais de estimação." },
                    { 5, 0, 0, null, 0, true, 0, 0, 0, 2, 0, 0, "Imóvel alugado onde são permitidos animais de estimação." },
                    { 6, 0, 0, null, 50, true, 0, 50, 0, 2, 0, 0, "Imóvel próprio ou alugado, mas não sei se animais de estimação são permitidos." },
                    { 7, 0, 0, null, 0, true, 0, 0, 0, 3, 0, 0, "Casa com área externa (quintal, jardim, etc)." },
                    { 8, 0, 0, null, 0, true, 10, 0, 0, 3, 0, 0, "Casa sem área externa." },
                    { 9, 0, 0, null, 0, true, 50, 0, 0, 3, 0, 0, "Casa com muro baixo." },
                    { 10, 0, 0, null, 0, true, 20, 0, 10, 3, 0, 0, "Apartamento com tela." },
                    { 11, 0, 0, null, 0, true, 25, 0, 15, 3, 0, 10, "Apartamento sem tela." },
                    { 12, 0, 0, null, 0, true, 0, 0, 0, 4, 0, 0, "Casa com área externa (quintal, jardim, etc)." },
                    { 13, 0, 0, null, 0, true, 0, 0, 0, 4, 0, 0, "Casa sem área externa." },
                    { 14, 0, 0, null, 25, true, 0, 25, 0, 4, 0, 0, "Casa com muro baixo." },
                    { 15, 0, 0, null, 0, true, 0, 0, 0, 4, 0, 0, "Apartamento com tela." },
                    { 16, 0, 0, null, 20, true, 0, 20, 0, 4, 0, 0, "Apartamento sem tela." },
                    { 17, 0, 0, null, 20, true, 0, 20, 0, 5, 0, 0, "Por mais de 12 horas ao dia." },
                    { 18, 0, 0, null, 10, true, 0, 10, 0, 5, 0, 0, "De 6 a 12 horas ao dia." },
                    { 19, 0, 0, null, 0, true, 0, 0, 0, 5, 0, 0, "Menos de 6 horas ao dia." },
                    { 20, 0, 0, null, 20, true, 0, 20, 0, 6, 0, 0, "Por mais de 12 horas ao dia." },
                    { 21, 0, 0, null, 10, true, 0, 10, 0, 6, 0, 0, "De 6 a 12 horas ao dia." },
                    { 22, 0, 0, null, 0, true, 0, 0, 0, 6, 0, 0, "Menos de 6 horas ao dia." },
                    { 23, 0, 0, null, 0, true, 0, 0, 0, 7, 0, 0, "Não." },
                    { 24, 0, 0, null, 0, true, 0, 0, 0, 7, 0, 0, "Há um ou mais pets." },
                    { 25, 0, 0, null, 0, true, 0, 0, 0, 8, 0, 0, "Não." },
                    { 26, 0, 0, null, 0, true, 0, 0, 0, 8, 0, 0, "Há um ou mais pets." },
                    { 27, 0, 0, null, 0, true, 0, 0, 0, 9, 0, 0, "Sim." },
                    { 28, 0, 0, null, 50, true, 0, 50, 0, 9, 0, 0, "Não." },
                    { 29, 0, 0, null, 0, true, 0, 0, 0, 10, 0, 0, "Sim." },
                    { 30, 0, 0, null, 50, true, 0, 50, 0, 10, 0, 0, "Não." },
                    { 31, 0, 0, null, 0, true, 0, 0, 0, 11, 0, 0, "Sim." },
                    { 32, 0, 0, null, 50, true, 0, 50, 0, 11, 0, 0, "Não." },
                    { 33, 0, 0, null, 0, true, 0, 0, 0, 12, 0, 0, "Sim." },
                    { 34, 0, 0, null, 50, true, 0, 50, 0, 12, 0, 0, "Não." },
                    { 35, 0, 0, null, 0, true, 0, 0, 0, 13, 0, 0, "Ração seca/úmida e/ou alimentos específicos para cachorros." },
                    { 36, 0, 0, null, 20, true, 0, 20, 0, 13, 0, 0, "Sobras de refeições." },
                    { 37, 0, 0, null, 0, true, 0, 0, 0, 14, 0, 0, "Ração seca/úmida e/ou alimentos específicos para gatos." },
                    { 38, 0, 0, null, 20, true, 0, 20, 0, 14, 0, 0, "Sobras de refeições." },
                    { 39, 0, 0, null, 0, true, 0, 0, 0, 15, 0, 0, "Sim, diariamente." },
                    { 40, 5, 10, null, 0, true, 20, 0, 0, 15, 0, 0, "Sim, de 3 a 5 vezes por semana." },
                    { 41, 10, 15, null, 0, true, 30, 0, 15, 15, 5, 10, "Sim, de 1 a 2 vezes por semana." },
                    { 42, 0, 0, null, 50, true, 0, 50, 0, 15, 0, 0, "Não." },
                    { 43, 0, 0, null, 0, true, 0, 0, 0, 16, 0, 0, "Sim." },
                    { 44, 0, 0, null, 0, true, 0, 0, 0, 16, 0, 0, "Não, mas comprarei para o pet." },
                    { 45, 0, 0, null, 20, true, 0, 20, 0, 16, 0, 0, "Não, mas não será necessário." },
                    { 46, 0, 0, null, 0, true, 0, 0, 0, 17, 0, 0, "Sim." },
                    { 47, 0, 0, null, 50, true, 0, 50, 0, 17, 0, 0, "Não." },
                    { 48, 0, 0, null, 0, true, 0, 0, 0, 18, 0, 0, "Sim." },
                    { 49, 0, 0, null, 50, true, 0, 50, 0, 18, 0, 0, "Não." },
                    { 50, 0, 0, null, 0, true, 0, 0, 0, 19, 0, 0, "Sim." },
                    { 51, 0, 0, null, 50, true, 0, 50, 0, 19, 0, 0, "Não." },
                    { 52, 0, 0, null, 0, true, 0, 0, 0, 20, 0, 0, "Sim." },
                    { 53, 0, 0, null, 50, true, 0, 50, 0, 20, 0, 0, "Não." }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Alternatives",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
