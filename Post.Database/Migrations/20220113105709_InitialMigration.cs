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
                    { new Guid("5cfa2115-d60c-4d8c-941c-634386b2f616"), new string[0], new string[0] },
                    { new Guid("acdfb37c-82b0-4406-8e70-121c7043af48"), new string[0], new string[0] }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscription");
        }
    }
}
