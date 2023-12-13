using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SitePustok.Migrations
{
    public partial class jsjdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Blog_BlogId1",
                table: "BlogTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Tag_TagId1",
                table: "BlogTag");

            migrationBuilder.DropIndex(
                name: "IX_BlogTag_BlogId1",
                table: "BlogTag");

            migrationBuilder.DropIndex(
                name: "IX_BlogTag_TagId1",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "BlogId1",
                table: "BlogTag");

            migrationBuilder.DropColumn(
                name: "TagId1",
                table: "BlogTag");

            migrationBuilder.AlterColumn<int>(
                name: "TagId",
                table: "BlogTag",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BlogId",
                table: "BlogTag",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_BlogId",
                table: "BlogTag",
                column: "BlogId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_TagId",
                table: "BlogTag",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Blog_BlogId",
                table: "BlogTag",
                column: "BlogId",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Tag_TagId",
                table: "BlogTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Blog_BlogId",
                table: "BlogTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogTag_Tag_TagId",
                table: "BlogTag");

            migrationBuilder.DropIndex(
                name: "IX_BlogTag_BlogId",
                table: "BlogTag");

            migrationBuilder.DropIndex(
                name: "IX_BlogTag_TagId",
                table: "BlogTag");

            migrationBuilder.AlterColumn<string>(
                name: "TagId",
                table: "BlogTag",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BlogId",
                table: "BlogTag",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BlogId1",
                table: "BlogTag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TagId1",
                table: "BlogTag",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_BlogId1",
                table: "BlogTag",
                column: "BlogId1");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTag_TagId1",
                table: "BlogTag",
                column: "TagId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Blog_BlogId1",
                table: "BlogTag",
                column: "BlogId1",
                principalTable: "Blog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogTag_Tag_TagId1",
                table: "BlogTag",
                column: "TagId1",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
