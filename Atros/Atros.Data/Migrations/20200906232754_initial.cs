using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Atros.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "MovieEvaluation"
            //    );
            //migrationBuilder.DropTable(
            //    name: "Movie");
            //migrationBuilder.DropTable(
            //    name: "User");

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<byte>(nullable: false, defaultValue: (byte)1),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValue: new DateTime(2020, 9, 7, 2, 27, 54, 467, DateTimeKind.Local).AddTicks(9033)),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Popularity = table.Column<decimal>(nullable: false),
                    VoteCount = table.Column<int>(nullable: false),
                    OriginalLanguage = table.Column<string>(nullable: false),
                    OriginalTitle = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    VoteAverage = table.Column<decimal>(nullable: false),
                    Adult = table.Column<bool>(nullable: false),
                    Video = table.Column<bool>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Overview = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<byte>(nullable: false, defaultValue: (byte)1),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValue: new DateTime(2020, 9, 7, 2, 27, 54, 463, DateTimeKind.Local).AddTicks(1059)),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    UserName = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieEvaluation",
                columns: table => new
                {
                    MovieId = table.Column<long>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Status = table.Column<byte>(nullable: false, defaultValue: (byte)1),
                    CreateDate = table.Column<DateTime>(type: "DateTime", nullable: false, defaultValue: new DateTime(2020, 9, 7, 2, 27, 54, 473, DateTimeKind.Local).AddTicks(7734)),
                    UpdateDate = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Note = table.Column<string>(maxLength: 255, nullable: false),
                    Score = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieEvaluation", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MovieEvaluationEntity_Movie",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieEvaluationEntity_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Password", "Status", "UpdateDate", "UserName" },
                values: new object[] { new Guid("5fb2c73b-afb0-4cd5-9b80-45a1c3510851"), new DateTime(2020, 9, 7, 2, 27, 54, 478, DateTimeKind.Local).AddTicks(6714), "123456", (byte)1, null, "berkemre" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateDate", "Password", "Status", "UpdateDate", "UserName" },
                values: new object[] { new Guid("8cc0e103-39af-4574-b31a-591bb4c94a1c"), new DateTime(2020, 9, 7, 2, 27, 54, 478, DateTimeKind.Local).AddTicks(7935), "123456", (byte)1, null, "ogulcan" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieEvaluation_UserId",
                table: "MovieEvaluation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieEvaluation");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
