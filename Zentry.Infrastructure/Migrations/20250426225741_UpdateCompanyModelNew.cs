using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zentry.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyModelNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Services_CompanyId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Services_CompanyId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Businesses_BusinessId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Services_CategoryId",
                table: "Companies",
                newName: "IX_Companies_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_BusinessId",
                table: "Companies",
                newName: "IX_Companies_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Companies_CompanyId",
                table: "Bookings",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Businesses_BusinessId",
                table: "Companies",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Categories_CategoryId",
                table: "Companies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Companies_CompanyId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Businesses_BusinessId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Categories_CategoryId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Companies_CompanyId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_CategoryId",
                table: "Services",
                newName: "IX_Services_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_BusinessId",
                table: "Services",
                newName: "IX_Services_BusinessId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Businesses_BusinessId",
                table: "Services",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Categories_CategoryId",
                table: "Services",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
