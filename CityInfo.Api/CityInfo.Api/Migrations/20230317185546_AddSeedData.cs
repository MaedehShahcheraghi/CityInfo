using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CityInfo.Api.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Descreption", "Name" },
                values: new object[] { 1, "this is tehran", "tehran" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Descreption", "Name" },
                values: new object[] { 2, "this is shiraz", "shiraz" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Descreption", "Name" },
                values: new object[] { 3, "this is gheshm", "gheshm" });

            migrationBuilder.InsertData(
                table: "pointOfIntrests",
                columns: new[] { "Id", "CityId", "Descreption", "Name" },
                values: new object[] { 1, 1, "this is tange washi", "tange washi" });

            migrationBuilder.InsertData(
                table: "pointOfIntrests",
                columns: new[] { "Id", "CityId", "Descreption", "Name" },
                values: new object[] { 2, 1, "this is tange washi", "kakh sad abad" });

            migrationBuilder.InsertData(
                table: "pointOfIntrests",
                columns: new[] { "Id", "CityId", "Descreption", "Name" },
                values: new object[] { 3, 2, "this is tange masged nasir ", "masged nasir" });

            migrationBuilder.InsertData(
                table: "pointOfIntrests",
                columns: new[] { "Id", "CityId", "Descreption", "Name" },
                values: new object[] { 4, 2, "this is aramgah sadi", "aramgah saddi" });

            migrationBuilder.InsertData(
                table: "pointOfIntrests",
                columns: new[] { "Id", "CityId", "Descreption", "Name" },
                values: new object[] { 5, 3, "this gheshm abad ", "gheshm abad" });

            migrationBuilder.InsertData(
                table: "pointOfIntrests",
                columns: new[] { "Id", "CityId", "Descreption", "Name" },
                values: new object[] { 6, 3, "this is gheshmak", "geshmak" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "pointOfIntrests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pointOfIntrests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "pointOfIntrests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pointOfIntrests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "pointOfIntrests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "pointOfIntrests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
