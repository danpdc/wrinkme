using Microsoft.EntityFrameworkCore.Migrations;

namespace WrinkeMe.Dal.Migrations
{
    public partial class addOwnedRequestTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Browser_BrowserId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_Device_DeviceId",
                table: "Requests");

            migrationBuilder.DropForeignKey(
                name: "FK_Requests_OS_OSId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_BrowserId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_DeviceId",
                table: "Requests");

            migrationBuilder.DropIndex(
                name: "IX_Requests_OSId",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OS",
                table: "OS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Browser",
                table: "Browser");

            migrationBuilder.DropColumn(
                name: "BrowserId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "OSId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OS");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Device");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Browser");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameTable(
                name: "Browser",
                newName: "Browsers");

            migrationBuilder.AddColumn<int>(
                name: "UserAgentId",
                table: "OS",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserAgentId",
                table: "Devices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserAgentId",
                table: "Browsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OS",
                table: "OS",
                column: "UserAgentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "UserAgentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Browsers",
                table: "Browsers",
                column: "UserAgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Browsers_Requests_UserAgentId",
                table: "Browsers",
                column: "UserAgentId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Requests_UserAgentId",
                table: "Devices",
                column: "UserAgentId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OS_Requests_UserAgentId",
                table: "OS",
                column: "UserAgentId",
                principalTable: "Requests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Browsers_Requests_UserAgentId",
                table: "Browsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Requests_UserAgentId",
                table: "Devices");

            migrationBuilder.DropForeignKey(
                name: "FK_OS_Requests_UserAgentId",
                table: "OS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OS",
                table: "OS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Browsers",
                table: "Browsers");

            migrationBuilder.DropColumn(
                name: "UserAgentId",
                table: "OS");

            migrationBuilder.DropColumn(
                name: "UserAgentId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UserAgentId",
                table: "Browsers");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameTable(
                name: "Browsers",
                newName: "Browser");

            migrationBuilder.AddColumn<int>(
                name: "BrowserId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeviceId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OSId",
                table: "Requests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OS",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Device",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Browser",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OS",
                table: "OS",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Browser",
                table: "Browser",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_BrowserId",
                table: "Requests",
                column: "BrowserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_DeviceId",
                table: "Requests",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OSId",
                table: "Requests",
                column: "OSId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Browser_BrowserId",
                table: "Requests",
                column: "BrowserId",
                principalTable: "Browser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Device_DeviceId",
                table: "Requests",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_OS_OSId",
                table: "Requests",
                column: "OSId",
                principalTable: "OS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
