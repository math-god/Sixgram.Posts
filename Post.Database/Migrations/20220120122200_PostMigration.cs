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
                    subscriptions = table.Column<string[]>(type: "text[]", nullable: false)
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
                    commentaries = table.Column<string[]>(type: "text[]", nullable: false)
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
                    commentary = table.Column<string>(type: "text", nullable: false)
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
                columns: new[] { "user_id", "subscribers", "subscriptions" },
                values: new object[,]
                {
                    { new Guid("a75ec510-fec2-4dbb-a6cb-aba1da7e48bc"), new string[0], new string[0] },
                    { new Guid("b65d2233-8fc9-4015-b481-4967cdeae822"), new string[0], new string[0] }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "post_id", "commentaries", "file_id", "user_id" },
                values: new object[] { new Guid("3438a1dc-57cf-4c54-81d0-d26a31583693"), new string[0], new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000") });

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
