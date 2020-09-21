using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gastos.Data.Migrations
{
    public partial class OwnStructureInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cat");

            migrationBuilder.CreateTable(
                name: "TypeTransactions",
                columns: table => new
                {
                    TypeTransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeTransactions", x => x.TypeTransactionID);
                });

            migrationBuilder.CreateTable(
                name: "Icons",
                schema: "Cat",
                columns: table => new
                {
                    IconID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IconName = table.Column<string>(maxLength: 50, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Active = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Icons", x => x.IconID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    RegisterDate = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    Active = table.Column<bool>(nullable: false, defaultValue: true),
                    IconID = table.Column<int>(nullable: false),
                    TypeTransactionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_Icons_IconID",
                        column: x => x.IconID,
                        principalSchema: "Cat",
                        principalTable: "Icons",
                        principalColumn: "IconID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_TypeTransactions_TypeTransactionID",
                        column: x => x.TypeTransactionID,
                        principalTable: "TypeTransactions",
                        principalColumn: "TypeTransactionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActionDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 25, nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    TypeTransactionID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_Transactions_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TypeTransactions_TypeTransactionID",
                        column: x => x.TypeTransactionID,
                        principalTable: "TypeTransactions",
                        principalColumn: "TypeTransactionID");
                    table.ForeignKey(
                        name: "FK_Transactions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IconID",
                table: "Categories",
                column: "IconID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_TypeTransactionID",
                table: "Categories",
                column: "TypeTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CategoryID",
                table: "Transactions",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TypeTransactionID",
                table: "Transactions",
                column: "TypeTransactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Icons",
                schema: "Cat");

            migrationBuilder.DropTable(
                name: "TypeTransactions");
        }
    }
}
