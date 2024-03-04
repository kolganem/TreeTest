using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TreeWebAPI.Migrations
{
    public partial class UpdateTreeNode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreeNode_TreeNode_ParentId",
                table: "TreeNode");

            migrationBuilder.AddForeignKey(
                name: "FK_TreeNode_TreeNode_ParentId",
                table: "TreeNode",
                column: "ParentId",
                principalTable: "TreeNode",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreeNode_TreeNode_ParentId",
                table: "TreeNode");

            migrationBuilder.AddForeignKey(
                name: "FK_TreeNode_TreeNode_ParentId",
                table: "TreeNode",
                column: "ParentId",
                principalTable: "TreeNode",
                principalColumn: "Id");
        }
    }
}
