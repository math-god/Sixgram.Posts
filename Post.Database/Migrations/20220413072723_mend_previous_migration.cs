using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Post.Database.Migrations
{
    public partial class mend_previous_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "post_id",
                keyValue: new Guid("31ead996-0fb5-4b13-b1a8-6f2c6287c211"));

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "post_id",
                keyValue: new Guid("b07f377f-a9ce-4ee6-a78e-f328561ff3e6"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "subscription_id",
                keyValue: new Guid("261b9381-f497-49dd-aaec-f7393e778b35"));

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "subscription_id",
                keyValue: new Guid("6b9f3fe5-cae9-436d-bca0-a12b4bc21bf5"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
