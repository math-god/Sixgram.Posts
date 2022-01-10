using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Post.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscription",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subscribers = table.Column<string[]>(type: "text[]", nullable: false),
                    subscriptions = table.Column<string[]>(type: "text[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription", x => x.user_id);
                });

            migrationBuilder.InsertData(
                table: "subscription",
                columns: new[] { "user_id", "subscribers", "subscriptions" },
                values: new object[,]
                {
                    { new Guid("ab595a68-9f55-4c5b-9098-fb4fcbf0b193"), new string[0], new string[0] },
                    { new Guid("b040e56b-93a6-4366-9118-56322c308751"), new string[0], new string[0] }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscription");
        }
    }
}
