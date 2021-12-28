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
                    subscribers = table.Column<Guid[]>(type: "uuid[]", nullable: false),
                    subscriptions = table.Column<Guid[]>(type: "uuid[]", nullable: false)
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
                    { new Guid("48c72a5c-cd56-42f6-a09b-6638efd03475"), new Guid[0], new Guid[0] },
                    { new Guid("fc829ad5-a0c4-4fef-8ac1-1c47100bc03a"), new Guid[0], new Guid[0] }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscription");
        }
    }
}
