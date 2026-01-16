using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First.EmailReminder.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSnakeCaseConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_ReminderRules_ReminderRuleId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReminderRules_Users_UserId",
                table: "ReminderRules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Emails",
                table: "Emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReminderRules",
                table: "ReminderRules");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Emails",
                newName: "emails");

            migrationBuilder.RenameTable(
                name: "ReminderRules",
                newName: "reminder_rules");

            migrationBuilder.RenameIndex(
                name: "IX_Emails_ReminderRuleId",
                table: "emails",
                newName: "IX_emails_ReminderRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_ReminderRules_UserId",
                table: "reminder_rules",
                newName: "IX_reminder_rules_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_emails",
                table: "emails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reminder_rules",
                table: "reminder_rules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_emails_reminder_rules_ReminderRuleId",
                table: "emails",
                column: "ReminderRuleId",
                principalTable: "reminder_rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reminder_rules_users_UserId",
                table: "reminder_rules",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emails_reminder_rules_ReminderRuleId",
                table: "emails");

            migrationBuilder.DropForeignKey(
                name: "FK_reminder_rules_users_UserId",
                table: "reminder_rules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emails",
                table: "emails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reminder_rules",
                table: "reminder_rules");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "emails",
                newName: "Emails");

            migrationBuilder.RenameTable(
                name: "reminder_rules",
                newName: "ReminderRules");

            migrationBuilder.RenameIndex(
                name: "IX_emails_ReminderRuleId",
                table: "Emails",
                newName: "IX_Emails_ReminderRuleId");

            migrationBuilder.RenameIndex(
                name: "IX_reminder_rules_UserId",
                table: "ReminderRules",
                newName: "IX_ReminderRules_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Emails",
                table: "Emails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReminderRules",
                table: "ReminderRules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_ReminderRules_ReminderRuleId",
                table: "Emails",
                column: "ReminderRuleId",
                principalTable: "ReminderRules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReminderRules_Users_UserId",
                table: "ReminderRules",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
