using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectE.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class v3_authcolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "varchar(180)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Customers",
                type: "varchar(180)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Customers");
        }
    }
}
