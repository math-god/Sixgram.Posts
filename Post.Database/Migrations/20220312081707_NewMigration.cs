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
                    description = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: false),
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

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "post_id", "day_created", "description", "file_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("45ed469e-7471-4662-b2f0-576bd969e818"), new DateTime(2022, 3, 12, 11, 17, 7, 360, DateTimeKind.Local).AddTicks(9191), "Eu cum iuvaret debitis voluptatibus, esse perfecto reformidans id has.", new Guid("81889ddf-aa61-4fdc-b9ef-037b56677353"), new Guid("07587c3f-dd72-4bfc-ac08-ff374de1cf25") },
                    { new Guid("9b1ef0bc-6f56-4ee0-a3dd-a186bc952def"), new DateTime(2022, 3, 12, 11, 17, 7, 360, DateTimeKind.Local).AddTicks(9196), "Tation delenit percipitur at vix. Tation delenit percipitur at vix", new Guid("2167ca73-7e25-41f7-bfc5-9c85a0efb884"), new Guid("e8756f2b-b509-4a19-a8d8-ffc90b92c378") }
                });

            migrationBuilder.InsertData(
                table: "subscription",
                columns: new[] { "id", "day_created", "respondent_id", "subscriber_id" },
                values: new object[,]
                {
                    { new Guid("02106d1d-c80b-43f8-acd3-97c584fc2137"), new DateTime(2022, 3, 12, 11, 17, 7, 360, DateTimeKind.Local).AddTicks(8479), new Guid("1dc0ca07-0686-4a8d-a223-1a8bf11b2c4d"), new Guid("4fb90a9a-4b5c-4794-8cbc-c58e9dad4b93") },
                    { new Guid("f243908e-cba3-467e-bbfc-9ca80baa6519"), new DateTime(2022, 3, 12, 11, 17, 7, 360, DateTimeKind.Local).AddTicks(8510), new Guid("02a1387d-4ff9-4e7c-800a-60291d3a1906"), new Guid("4b2cf11d-c2ee-4b2a-885b-c84abde13509") }
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
