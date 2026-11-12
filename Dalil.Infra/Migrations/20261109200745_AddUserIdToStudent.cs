using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dalil.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Addres",
                table: "Students",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Students",
                newName: "Addres");
        }
    }
}
