using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zentry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Services_ServiceId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Services_ServiceId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ServiceId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Employees",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ServiceId",
                table: "Employees",
                newName: "IX_Employees_CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyAddress",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyPhone",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Services",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Bookings",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CompanyId",
                table: "Bookings",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Services_CompanyId",
                table: "Bookings",
                column: "CompanyId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Services_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Services_CompanyId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Services_CompanyId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CompanyId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "CompanyAddress",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CompanyPhone",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Employees",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CompanyId",
                table: "Employees",
                newName: "IX_Employees_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ServiceId",
                table: "Bookings",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Services_ServiceId",
                table: "Bookings",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Services_ServiceId",
                table: "Employees",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
