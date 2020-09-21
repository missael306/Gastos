using Microsoft.EntityFrameworkCore.Migrations;

namespace Gastos.Data.Migrations
{
    public partial class InsertDataCatalogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TypeTransactions",
                columns: new[] { "TypeTransactionID", "Name" },
                values: new object[,]
                {
                    { 1, "Gasto" },
                    { 2, "Ingreso" }
                });

            migrationBuilder.InsertData(
                schema: "Cat",
                table: "Icons",
                columns: new[] { "IconID", "IconName" },
                values: new object[,]
                {
                    { 1, "fas fa-glass-cheers" },
                    { 2, "fas fa-hospital" },
                    { 3, "fas fa-wallet" },
                    { 4, "fas fa-car" },
                    { 5, "fas fa-house-user" },
                    { 6, "fas fa-utensils" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Active", "IconID", "Name", "TypeTransactionID" },
                values: new object[,]
                {
                    { 1, true, 1, "Entretenimiento", 1 },
                    { 2, true, 2, "Salud", 1 },
                    { 4, true, 4, "Automóvil", 1 },
                    { 5, true, 5, "Casa", 1 },
                    { 6, true, 6, "Comida", 1 },
                    { 3, true, 3, "Salario", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeTransactions",
                keyColumn: "TypeTransactionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeTransactions",
                keyColumn: "TypeTransactionID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 6);
        }
    }
}
