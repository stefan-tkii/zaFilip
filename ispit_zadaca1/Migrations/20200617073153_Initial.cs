using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ispit_zadaca1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: true),
                    indeks = table.Column<string>(nullable: true),
                    signature = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vezbi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    desc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vezbi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentlabs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentId = table.Column<int>(nullable: false),
                    labvezbaId = table.Column<int>(nullable: false),
                    finished = table.Column<bool>(nullable: false),
                    points = table.Column<int>(nullable: false),
                    finishDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentlabs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentlabs_vezbi_labvezbaId",
                        column: x => x.labvezbaId,
                        principalTable: "vezbi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentlabs_students_studentId",
                        column: x => x.studentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentlabs_labvezbaId",
                table: "studentlabs",
                column: "labvezbaId");

            migrationBuilder.CreateIndex(
                name: "IX_studentlabs_studentId",
                table: "studentlabs",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "studentlabs");

            migrationBuilder.DropTable(
                name: "vezbi");

            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
