using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectoryOrganizations.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Organizations_OrganizationId",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "IdOrganization",
                table: "Branches");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Organizations_OrganizationId",
                table: "Branches",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Branches_Organizations_OrganizationId",
                table: "Branches");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "Branches",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "IdOrganization",
                table: "Branches",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Branches_Organizations_OrganizationId",
                table: "Branches",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }
    }
}
