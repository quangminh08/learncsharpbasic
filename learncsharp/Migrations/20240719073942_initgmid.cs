using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace learnteddy.Migrations
{
    /// <inheritdoc />
    public partial class initgmid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_group_member_AspNetUsers_AppUserId1",
                table: "tbl_group_member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_group_member",
                table: "tbl_group_member");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3130bc94-0c09-4555-b01d-eec40f83ac72");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b76c4177-f07d-4828-8c27-76aed48f63ab");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "tbl_group_member");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "tbl_group_member",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tbl_group",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "tbl_group",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_group_member",
                table: "tbl_group_member",
                columns: new[] { "AppUserId", "GroupId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c2bf33cf-de95-45dd-b874-08712f32d39b", null, "Admin", "ADMIN" },
                    { "f40d78eb-4930-4fba-a7b5-a57911d1386e", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_group_member_AspNetUsers_AppUserId",
                table: "tbl_group_member",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_group_member_AspNetUsers_AppUserId",
                table: "tbl_group_member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_group_member",
                table: "tbl_group_member");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2bf33cf-de95-45dd-b874-08712f32d39b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f40d78eb-4930-4fba-a7b5-a57911d1386e");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "tbl_group_member",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "tbl_group_member",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tbl_group",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Avatar",
                table: "tbl_group",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_group_member",
                table: "tbl_group_member",
                columns: new[] { "AppUserId1", "GroupId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3130bc94-0c09-4555-b01d-eec40f83ac72", null, "Admin", "ADMIN" },
                    { "b76c4177-f07d-4828-8c27-76aed48f63ab", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_group_member_AspNetUsers_AppUserId1",
                table: "tbl_group_member",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
