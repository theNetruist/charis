using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeonTek.Charis.API.Migrations
{
    /// <inheritdoc />
    public partial class organization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Volunteers_VolunteerId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Waiver_Volunteers_VolunteerId",
                table: "Waiver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaiverTemplates",
                table: "WaiverTemplates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteers",
                table: "Volunteers");

            migrationBuilder.RenameTable(
                name: "WaiverTemplates",
                newName: "WaiverTemplate");

            migrationBuilder.RenameTable(
                name: "Volunteers",
                newName: "Volunteer");

            migrationBuilder.AlterColumn<Guid>(
                name: "VolunteerId",
                table: "Waiver",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "Waiver",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SignedDate",
                table: "Waiver",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Waiver",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "VolunteerId",
                table: "Contact",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Contact",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contact",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contact",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Contact",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AllowText",
                table: "Contact",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Contact",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "WaiverTemplate",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "WaiverTemplate",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "MarkDown",
                table: "WaiverTemplate",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "WaiverTemplate",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "WaiverTemplate",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Volunteer",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Volunteer",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Volunteer",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizationId",
                table: "Volunteer",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaiverTemplate",
                table: "WaiverTemplate",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volunteer",
                table: "Volunteer",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaiverTemplate_OrganizationId",
                table: "WaiverTemplate",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_OrganizationId",
                table: "Volunteer",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_Name",
                table: "Organizations",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Volunteer_VolunteerId",
                table: "Contact",
                column: "VolunteerId",
                principalTable: "Volunteer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Volunteer_Organizations_OrganizationId",
                table: "Volunteer",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Waiver_Volunteer_VolunteerId",
                table: "Waiver",
                column: "VolunteerId",
                principalTable: "Volunteer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WaiverTemplate_Organizations_OrganizationId",
                table: "WaiverTemplate",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Volunteer_VolunteerId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Volunteer_Organizations_OrganizationId",
                table: "Volunteer");

            migrationBuilder.DropForeignKey(
                name: "FK_Waiver_Volunteer_VolunteerId",
                table: "Waiver");

            migrationBuilder.DropForeignKey(
                name: "FK_WaiverTemplate_Organizations_OrganizationId",
                table: "WaiverTemplate");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WaiverTemplate",
                table: "WaiverTemplate");

            migrationBuilder.DropIndex(
                name: "IX_WaiverTemplate_OrganizationId",
                table: "WaiverTemplate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Volunteer",
                table: "Volunteer");

            migrationBuilder.DropIndex(
                name: "IX_Volunteer_OrganizationId",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "WaiverTemplate");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "Volunteer");

            migrationBuilder.RenameTable(
                name: "WaiverTemplate",
                newName: "WaiverTemplates");

            migrationBuilder.RenameTable(
                name: "Volunteer",
                newName: "Volunteers");

            migrationBuilder.AlterColumn<Guid>(
                name: "VolunteerId",
                table: "Waiver",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "Waiver",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SignedDate",
                table: "Waiver",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Waiver",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "VolunteerId",
                table: "Contact",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Contact",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Contact",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Contact",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "Contact",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "AllowText",
                table: "Contact",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Contact",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                table: "WaiverTemplates",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "WaiverTemplates",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "MarkDown",
                table: "WaiverTemplates",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "WaiverTemplates",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Volunteers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Volunteers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Volunteers",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WaiverTemplates",
                table: "WaiverTemplates",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Volunteers",
                table: "Volunteers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Volunteers_VolunteerId",
                table: "Contact",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Waiver_Volunteers_VolunteerId",
                table: "Waiver",
                column: "VolunteerId",
                principalTable: "Volunteers",
                principalColumn: "Id");
        }
    }
}
