using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerSkills");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Skills",
                type: "varchar(180)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(180)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Skills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "varchar(180)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(180)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CustomerId",
                table: "Skills",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Customers_CustomerId",
                table: "Skills",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Customers_CustomerId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CustomerId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Skills");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Skills",
                type: "varchar(180)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(180)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "varchar(180)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(180)");

            migrationBuilder.CreateTable(
                name: "CustomerSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerSkills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSkills_CustomerId",
                table: "CustomerSkills",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerSkills_SkillId",
                table: "CustomerSkills",
                column: "SkillId");
        }
    }
}
