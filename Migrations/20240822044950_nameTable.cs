using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cSharpCrud.Migrations
{
    /// <inheritdoc />
    public partial class nameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stutent",
                table: "Stutent");

            migrationBuilder.RenameTable(
                name: "Stutent",
                newName: "Stutents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stutents",
                table: "Stutents",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Stutents",
                table: "Stutents");

            migrationBuilder.RenameTable(
                name: "Stutents",
                newName: "Stutent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stutent",
                table: "Stutent",
                column: "Id");
        }
    }
}
