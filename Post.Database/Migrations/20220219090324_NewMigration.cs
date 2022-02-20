using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Post.Database.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    post_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_id = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    day_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.post_id);
                });

            migrationBuilder.CreateTable(
                name: "subscription",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    respondent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subscriber_id = table.Column<Guid>(type: "uuid", nullable: false),
                    day_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "commentaries",
                columns: table => new
                {
                    commentary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    post_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    commentary = table.Column<string>(type: "text", nullable: false),
                    day_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentaries", x => x.commentary_id);
                    table.ForeignKey(
                        name: "FK_commentaries_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "subscription",
                columns: new[] { "id", "day_created", "respondent_id", "subscriber_id" },
                values: new object[,]
                {
                    { new Guid("65de5c15-4018-430c-9d44-56ccfd8a49e6"), new DateTime(2022, 2, 19, 12, 3, 24, 212, DateTimeKind.Local).AddTicks(5764), new Guid("25c93c42-0068-4457-bbbb-feb4d4f4390e"), new Guid("d554cc47-8abc-4630-856b-b29b00374eab") },
                    { new Guid("7eb0bde9-8fa3-4d30-9e55-89722a259a63"), new DateTime(2022, 2, 19, 12, 3, 24, 212, DateTimeKind.Local).AddTicks(5781), new Guid("bc65c6a6-12c0-4a5d-8b2a-6bc5970866c3"), new Guid("838d9c19-685f-4bcd-9d68-ab0ab00bd59d") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_commentaries_post_id",
                table: "commentaries",
                column: "post_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commentaries");

            migrationBuilder.DropTable(
                name: "subscription");

            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
