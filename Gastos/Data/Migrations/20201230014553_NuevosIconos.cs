using Microsoft.EntityFrameworkCore.Migrations;

namespace Gastos.Data.Migrations
{
    public partial class NuevosIconos : Migration
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
                table: "Categories",
                columns: new[] { "CategoryID", "Active", "IconID", "Name", "TypeTransactionID", "UserId" },
                values: new object[,]
                {
                    { 24, true, 40, "Accesorios", 1, null },
                    { 23, true, 38, "Gimnasio", 1, null },
                    { 22, true, 34, "Préstamo", 2, null },
                    { 21, true, 26, "TDC", 1, null },
                    { 19, true, 22, "Computación", 1, null },
                    { 20, true, 23, "Honorarios", 2, null },
                    { 17, true, 20, "Wifi", 1, null },
                    { 16, true, 19, "Ropa", 1, null },
                    { 15, true, 18, "Cumpleaños", 1, null },
                    { 14, true, 17, "Alcohol", 1, null },
                    { 13, true, 16, "Café", 1, null },
                    { 12, true, 15, "Taxi", 1, null },
                    { 11, true, 14, "Gasolina", 1, null },
                    { 10, true, 13, "Transporte", 1, null },
                    { 9, true, 12, "Emergencia", 1, null },
                    { 8, true, 10, "Bebé", 1, null },
                    { 18, true, 21, "Tv", 1, null },
                    { 7, true, 8, "Amazon", 1, null }
                });

            migrationBuilder.InsertData(
                schema: "Cat",
                table: "Icons",
                columns: new[] { "IconID", "IconName" },
                values: new object[,]
                {
                    { 41, "fas fa-chart-bar" },
                    { 42, "fas fa-chart-pie" },
                    { 43, "fas fa-chart-line" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Active", "IconID", "Name", "TypeTransactionID", "UserId" },
                values: new object[] { 25, true, 41, "Ventas", 2, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Active", "IconID", "Name", "TypeTransactionID", "UserId" },
                values: new object[] { 26, true, 42, "Rendimientos", 2, null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Active", "IconID", "Name", "TypeTransactionID", "UserId" },
                values: new object[] { 27, true, 43, "Inversión", 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                schema: "Cat",
                table: "Icons",
                keyColumn: "IconID",
                keyValue: 43);

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
