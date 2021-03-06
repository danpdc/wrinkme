﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace WrinkeMe.Dal.Migrations
{
    public partial class FullyQualifyUSerAgentConstraints : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "OSId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BrowserId",
                table: "Requests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Browser_BrowserId",
                table: "Requests",
                column: "BrowserId",
                principalTable: "Browser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_Device_DeviceId",
                table: "Requests",
                column: "DeviceId",
                principalTable: "Device",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Requests_OS_OSId",
                table: "Requests",
                column: "OSId",
                principalTable: "OS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "OSId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DeviceId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "BrowserId",
                table: "Requests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
