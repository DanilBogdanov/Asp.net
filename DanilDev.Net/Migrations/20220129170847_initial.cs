using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DanilDev.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostControlUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostControlUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostControlAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostControlAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostControlAccounts_CostControlUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "CostControlUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostControlExpenses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostControlExpenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostControlExpenses_CostControlExpenses_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CostControlExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostControlExpenses_CostControlUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "CostControlUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostControlIncomes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostControlIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostControlIncomes_CostControlIncomes_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CostControlIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostControlIncomes_CostControlUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "CostControlUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostControlBalances",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostControlBalances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostControlBalances_CostControlAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "CostControlAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CostControlTransactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountFromId = table.Column<long>(type: "bigint", nullable: true),
                    AccountToId = table.Column<long>(type: "bigint", nullable: true),
                    IncomeId = table.Column<long>(type: "bigint", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ExpenseId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostControlTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostControlTransactions_CostControlAccounts_AccountFromId",
                        column: x => x.AccountFromId,
                        principalTable: "CostControlAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostControlTransactions_CostControlAccounts_AccountToId",
                        column: x => x.AccountToId,
                        principalTable: "CostControlAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostControlTransactions_CostControlExpenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "CostControlExpenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostControlTransactions_CostControlIncomes_IncomeId",
                        column: x => x.IncomeId,
                        principalTable: "CostControlIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CostControlTransactions_CostControlUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "CostControlUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostControlAccounts_UserId",
                table: "CostControlAccounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlBalances_AccountId",
                table: "CostControlBalances",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlExpenses_ParentId",
                table: "CostControlExpenses",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlExpenses_UserId",
                table: "CostControlExpenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlIncomes_ParentId",
                table: "CostControlIncomes",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlIncomes_UserId",
                table: "CostControlIncomes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlTransactions_AccountFromId",
                table: "CostControlTransactions",
                column: "AccountFromId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlTransactions_AccountToId",
                table: "CostControlTransactions",
                column: "AccountToId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlTransactions_ExpenseId",
                table: "CostControlTransactions",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlTransactions_IncomeId",
                table: "CostControlTransactions",
                column: "IncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostControlTransactions_UserId",
                table: "CostControlTransactions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostControlBalances");

            migrationBuilder.DropTable(
                name: "CostControlTransactions");

            migrationBuilder.DropTable(
                name: "CostControlAccounts");

            migrationBuilder.DropTable(
                name: "CostControlExpenses");

            migrationBuilder.DropTable(
                name: "CostControlIncomes");

            migrationBuilder.DropTable(
                name: "CostControlUsers");
        }
    }
}
