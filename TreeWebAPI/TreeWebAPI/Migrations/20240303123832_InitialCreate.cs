using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeWebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeNode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeNode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TreeNode_TreeNode_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TreeNode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TreeNode_ParentId",
                table: "TreeNode",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeNode");
        }
    }
}
