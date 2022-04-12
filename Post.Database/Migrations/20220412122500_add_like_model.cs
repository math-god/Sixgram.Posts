using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Post.Database.Migrations
{
    public partial class add_like_model : Migration
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
                    description = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: false),
                    day_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.post_id);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    subscription_id = table.Column<Guid>(type: "uuid", nullable: false),
                    respondent_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subscriber_id = table.Column<Guid>(type: "uuid", nullable: false),
                    day_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.subscription_id);
                });

            migrationBuilder.CreateTable(
                name: "commentaries",
                columns: table => new
                {
                    commentary_id = table.Column<Guid>(type: "uuid", nullable: false),
                    post_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    commentary = table.Column<string>(type: "character varying(800)", maxLength: 800, nullable: false),
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

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    like_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    post_id = table.Column<Guid>(type: "uuid", nullable: false),
                    day_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => x.like_id);
                    table.ForeignKey(
                        name: "FK_likes_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "post_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "post_id", "day_created", "description", "file_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("31ead996-0fb5-4b13-b1a8-6f2c6287c211"), new DateTime(2022, 4, 12, 15, 25, 0, 672, DateTimeKind.Local).AddTicks(8165), "Eu cum iuvaret debitis voluptatibus, esse perfecto reformidans id has.", new Guid("f3c2d704-7f31-4530-8899-4ab54addb09d"), new Guid("8d8da77a-6fc3-4245-9d15-23bbd363843b") },
                    { new Guid("b07f377f-a9ce-4ee6-a78e-f328561ff3e6"), new DateTime(2022, 4, 12, 15, 25, 0, 672, DateTimeKind.Local).AddTicks(8172), "Tation delenit percipitur at vix. Tation delenit percipitur at vix", new Guid("825c557c-75b9-41b4-94a1-87d22d560cef"), new Guid("f955a266-254a-4626-91b1-a2b1415a86f6") }
                });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "subscription_id", "day_created", "respondent_id", "subscriber_id" },
                values: new object[,]
                {
                    { new Guid("261b9381-f497-49dd-aaec-f7393e778b35"), new DateTime(2022, 4, 12, 15, 25, 0, 672, DateTimeKind.Local).AddTicks(7394), new Guid("5bbe4c43-12c2-4a46-af60-afbfae516465"), new Guid("5a3c51ab-c100-4f45-b559-6919b2144214") },
                    { new Guid("6b9f3fe5-cae9-436d-bca0-a12b4bc21bf5"), new DateTime(2022, 4, 12, 15, 25, 0, 672, DateTimeKind.Local).AddTicks(7365), new Guid("534f619f-ff1b-4f3a-bea6-41cd6dc47c85"), new Guid("af93b103-d20d-4a4d-8ed4-3e33eeefb0c0") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_commentaries_post_id",
                table: "commentaries",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_likes_post_id",
                table: "likes",
                column: "post_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "commentaries");

            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
