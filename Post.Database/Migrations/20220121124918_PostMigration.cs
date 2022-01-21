using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Post.Database.Migrations
{
    public partial class PostMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "membership",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subscribers = table.Column<string[]>(type: "text[]", nullable: false),
                    subscriptions = table.Column<string[]>(type: "text[]", nullable: false),
                    day_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_membership", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    post_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    commentaries = table.Column<string[]>(type: "text[]", nullable: false),
                    day_created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.post_id);
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
                table: "membership",
                columns: new[] { "user_id", "day_created", "subscribers", "subscriptions" },
                values: new object[,]
                {
                    { new Guid("149c7712-3bdb-4da0-9e2d-81649b9d34ee"), new DateTime(2022, 1, 21, 15, 49, 18, 528, DateTimeKind.Local).AddTicks(4494), new string[0], new string[0] },
                    { new Guid("ba2836a5-86e7-4694-bf49-2dbe12fb237e"), new DateTime(2022, 1, 21, 15, 49, 18, 528, DateTimeKind.Local).AddTicks(4484), new string[0], new string[0] }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "post_id", "commentaries", "day_created", "description", "file_id", "user_id" },
                values: new object[] { new Guid("e1b7c670-5957-46ef-a00d-94b2701642dc"), new string[0], new DateTime(2022, 1, 21, 15, 49, 18, 528, DateTimeKind.Local).AddTicks(5009), "", new Guid("deca27d7-b0cb-44e9-b349-0c2b61bdfcf3"), new Guid("00000000-0000-0000-0000-000000000000") });

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
                name: "membership");

            migrationBuilder.DropTable(
                name: "posts");
        }
    }
}
