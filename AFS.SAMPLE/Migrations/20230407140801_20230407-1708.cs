using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFS.SAMPLE.Migrations
{
    /// <inheritdoc />
    public partial class _202304071708 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TokenExpiredMinute",
                schema: "dbo",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 60,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TokenExpiredMinute",
                schema: "dbo",
                table: "User",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 60);
        }
    }
}
