﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Birth = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "Birth", "Email", "name", "Phone" },
                values: new object[] { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "adam@wsei.edu.pl", "Adam", "127813268163" });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "Birth", "Email", "name", "Phone" },
                values: new object[] { 2, new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ewa@wsei.edu.pl", "Ewa", "293443823478" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");
        }
    }
}
