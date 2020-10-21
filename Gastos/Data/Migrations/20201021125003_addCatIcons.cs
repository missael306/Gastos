using Microsoft.EntityFrameworkCore.Migrations;

namespace Gastos.Data.Migrations
{
    public partial class addCatIcons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6,
                column: "Active",
                value: true);

            migrationBuilder.InsertData(
                schema: "Cat",
                table: "Icons",
                columns: new[] { "IconID", "IconName" },
                values: new object[,]
                {
                    { 39, "fas fa-house-user" },
                    { 38, "fas fa-dumbbell" },
                    { 37, "fas fa-gift" },
                    { 27, "fas fa-heartbeat" },
                    { 35, "fas fa-ambulance" },
                    { 34, "fas fa-hand-holding-usd" },
                    { 33, "fab fa-xbox" },
                    { 32, "fab fa-steam" },
                    { 31, "fab fa-playstation" },
                    { 30, "fas fa-dice" },
                    { 29, "fas fa-pizza-slice" },
                    { 28, "fas fa-bone" },
                    { 40, "fas fa-headphones" },
                    { 36, "far fa-hospital" },
                    { 26, "fas fa-credit-card" },
                    { 24, "fas fa-dollar-sign" },
                    { 8, "fab fa-amazon" },
                    { 9, "fab fa-apple" },
                    { 10, "fas fa-baby" },
                    { 11, "fas fa-bone" },
                    { 12, "fas fa-ambulance" },
                    { 13, "fas fa-bus-alt" },
                    { 14, "fas fa-gas-pump" },
                    { 25, "fas fa-graduation-cap" },
                    { 15, "fas fa-taxi" },
                    { 17, "fas fa-cocktail" },
                    { 18, "fas fa-birthday-cake" },
                    { 19, "fas fa-tshirt" },
                    { 20, "fas fa-wifi" },
                    { 21, "fas fa-tv" },
                    { 22, "fas fa-laptop" },
                    { 23, "fas fa-money-bill-wave" },
                    { 16, "fas fa-coffee" },
                    { 7, "fab fa-airbnb" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6,
                column: "Active",
                value: true);
        }
    }
}
