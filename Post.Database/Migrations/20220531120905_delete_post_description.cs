using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Post.Database.Migrations
{
    public partial class delete_post_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "post_id",
                keyValue: new Guid("3fb3f0ef-2a57-4f77-8a58-64373d07bb59"));

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "post_id",
                keyValue: new Guid("c61bcaca-4d31-49af-93d5-939848abe585"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "subscription_id",
                keyValue: new Guid("1173b93f-c5a2-4c8d-80fb-f9f3e3585ee7"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "subscription_id",
                keyValue: new Guid("a2a6ff36-92a9-4faf-a59e-bcb2a89ebf30"));

            migrationBuilder.DropColumn(
                name: "description",
                table: "posts");

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "post_id", "day_created", "file_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("26e95359-c98d-4128-a20b-e5c2077799d7"), new DateTime(2022, 5, 31, 15, 9, 4, 593, DateTimeKind.Local).AddTicks(1438), new Guid("4b54f11d-7aa9-4331-850a-df144b412208"), new Guid("b5b7990e-a4b1-45b5-a3f8-961a487e84f1") },
                    { new Guid("c378df60-efbc-4b8a-9b53-c8b42d7b0849"), new DateTime(2022, 5, 31, 15, 9, 4, 593, DateTimeKind.Local).AddTicks(1431), new Guid("e59a22ee-a6b8-445f-9c21-f7c26cac02e0"), new Guid("d13d9e72-c3b8-4f33-8a1e-5048f617258e") }
                });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "subscription_id", "day_created", "respondent_id", "subscriber_id" },
                values: new object[,]
                {
                    { new Guid("7a1fb12d-9522-4377-b0b4-f980d47e6e3a"), new DateTime(2022, 5, 31, 15, 9, 4, 593, DateTimeKind.Local).AddTicks(796), new Guid("5188564e-b48a-4bf5-8ce6-ae02cf9f68dc"), new Guid("4084d4fb-5b1c-4d1f-9278-41c0e0414145") },
                    { new Guid("8183c4de-9ae3-4425-b47d-594e7f5562e4"), new DateTime(2022, 5, 31, 15, 9, 4, 593, DateTimeKind.Local).AddTicks(809), new Guid("966f5664-2dad-44fd-93da-d34d171a7e57"), new Guid("5af274d4-f631-497f-a6c4-d8a49451dfbb") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "post_id",
                keyValue: new Guid("26e95359-c98d-4128-a20b-e5c2077799d7"));

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "post_id",
                keyValue: new Guid("c378df60-efbc-4b8a-9b53-c8b42d7b0849"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "subscription_id",
                keyValue: new Guid("7a1fb12d-9522-4377-b0b4-f980d47e6e3a"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "subscription_id",
                keyValue: new Guid("8183c4de-9ae3-4425-b47d-594e7f5562e4"));

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "posts",
                type: "character varying(2500)",
                maxLength: 2500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "post_id", "day_created", "description", "file_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("3fb3f0ef-2a57-4f77-8a58-64373d07bb59"), new DateTime(2022, 4, 13, 10, 27, 23, 67, DateTimeKind.Local).AddTicks(7735), "Eu cum iuvaret debitis voluptatibus, esse perfecto reformidans id has.", new Guid("99b2c558-7266-432a-96b2-014ac3d5306b"), new Guid("8f1260e6-d500-4540-a168-f4eddf84c23d") },
                    { new Guid("c61bcaca-4d31-49af-93d5-939848abe585"), new DateTime(2022, 4, 13, 10, 27, 23, 67, DateTimeKind.Local).AddTicks(7801), "Tation delenit percipitur at vix. Tation delenit percipitur at vix", new Guid("4ff28698-4892-49f6-b86e-7f6c5e109aab"), new Guid("87f4233e-71dd-477e-8129-42139db8eb3b") }
                });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "subscription_id", "day_created", "respondent_id", "subscriber_id" },
                values: new object[,]
                {
                    { new Guid("1173b93f-c5a2-4c8d-80fb-f9f3e3585ee7"), new DateTime(2022, 4, 13, 10, 27, 23, 67, DateTimeKind.Local).AddTicks(6846), new Guid("9f41bfcb-d91b-435e-8ea6-abfbc596ac9a"), new Guid("6a879896-082b-4bfe-b868-3d24304eb45a") },
                    { new Guid("a2a6ff36-92a9-4faf-a59e-bcb2a89ebf30"), new DateTime(2022, 4, 13, 10, 27, 23, 67, DateTimeKind.Local).AddTicks(6830), new Guid("88ebf469-1b41-4063-b628-184da6e0bd0b"), new Guid("0b9017f6-ff43-480e-9bfa-e8da33d1b3d7") }
                });
        }
    }
}
