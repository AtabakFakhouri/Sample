using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFS.SAMPLE.Migrations
{
    /// <inheritdoc />
    public partial class _20230408_1738 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslatedResponse",
                schema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Response",
                schema: "dbo",
                table: "TranslateRequest",
                newName: "ResponseTranslation");

            migrationBuilder.AddColumn<string>(
                name: "ResponseText",
                schema: "dbo",
                table: "TranslateRequest",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ResponseTotal",
                schema: "dbo",
                table: "TranslateRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ResponseTranslated",
                schema: "dbo",
                table: "TranslateRequest",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseText",
                schema: "dbo",
                table: "TranslateRequest");

            migrationBuilder.DropColumn(
                name: "ResponseTotal",
                schema: "dbo",
                table: "TranslateRequest");

            migrationBuilder.DropColumn(
                name: "ResponseTranslated",
                schema: "dbo",
                table: "TranslateRequest");

            migrationBuilder.RenameColumn(
                name: "ResponseTranslation",
                schema: "dbo",
                table: "TranslateRequest",
                newName: "Response");

            migrationBuilder.CreateTable(
                name: "TranslatedResponse",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranslateRequestId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteId = table.Column<long>(type: "bigint", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<long>(type: "bigint", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Translated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslatedResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslatedResponse_TranslateRequest_TranslateRequestId",
                        column: x => x.TranslateRequestId,
                        principalSchema: "dbo",
                        principalTable: "TranslateRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TranslatedResponse_TranslateRequestId",
                schema: "dbo",
                table: "TranslatedResponse",
                column: "TranslateRequestId",
                unique: true);
        }
    }
}
