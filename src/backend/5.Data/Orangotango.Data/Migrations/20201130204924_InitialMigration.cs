using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orangotango.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FristName = table.Column<string>(type: "VARCHAR(128)", nullable: true),
                    LastName = table.Column<string>(type: "VARCHAR(128)", nullable: true),
                    NickName = table.Column<string>(type: "VARCHAR(128)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(128)", nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(255)", nullable: true),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
