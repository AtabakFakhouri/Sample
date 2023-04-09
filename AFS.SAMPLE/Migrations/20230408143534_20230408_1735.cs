using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AFS.SAMPLE.Migrations
{
    /// <inheritdoc />
    public partial class _20230408_1735 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Request",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "TranslateRequest",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InputText = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Response = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    CreateId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditId = table.Column<long>(type: "bigint", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteId = table.Column<long>(type: "bigint", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslateRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslateRequest_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslatedResponse",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TranslateRequestId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Translated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateId = table.Column<long>(type: "bigint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditId = table.Column<long>(type: "bigint", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteId = table.Column<long>(type: "bigint", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_TranslateRequest_UserId",
                schema: "dbo",
                table: "TranslateRequest",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslatedResponse",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TranslateRequest",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Request",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateId = table.Column<long>(type: "bigint", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteId = table.Column<long>(type: "bigint", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<long>(type: "bigint", nullable: true),
                    InputText = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    Response = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Request_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Request_UserId",
                schema: "dbo",
                table: "Request",
                column: "UserId");
        }
    }
}
