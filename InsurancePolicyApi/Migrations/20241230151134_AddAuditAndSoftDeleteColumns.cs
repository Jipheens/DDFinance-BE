using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsurancePolicyApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditAndSoftDeleteColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeletedFlag",
                table: "InsurancePolicies",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedTime",
                table: "InsurancePolicies",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedTime",
                table: "InsurancePolicies",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostedTime",
                table: "InsurancePolicies",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedFlag",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "DeletedTime",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "ModifiedTime",
                table: "InsurancePolicies");

            migrationBuilder.DropColumn(
                name: "PostedTime",
                table: "InsurancePolicies");
        }
    }
}
