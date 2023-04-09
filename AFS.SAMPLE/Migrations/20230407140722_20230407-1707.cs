using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFS.SAMPLE.Migrations
{
    /// <inheritdoc />
    public partial class _202304071707 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TokenExpiredMinute",
                schema: "dbo",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TokenExpiredMinute",
                schema: "dbo",
                table: "User");
        }
    }
}
