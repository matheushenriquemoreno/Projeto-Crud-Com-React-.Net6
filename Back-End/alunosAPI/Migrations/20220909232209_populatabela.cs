using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace alunosAPI.Migrations
{
    public partial class populatabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Email", "Idade", "Nome" },
                values: new object[] { 1, "Matheus@gmail.com", 21, "Matheus Henrique" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
