using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SitePustok.Migrations
{
    public partial class BlogTagEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogBlogTag");

            migrationBuilder.DropTable(
                name: "BlogTagTag");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BlogBlogTag",
                columns: table => new
                {
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    BlogTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogBlogTag", x => new { x.BlogId, x.BlogTagId });
                    table.ForeignKey(
                        name: "FK_BlogBlogTag_Blog_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogBlogTag_BlogTag_BlogTagId",
                        column: x => x.BlogTagId,
                        principalTable: "BlogTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BlogTagTag",
                columns: table => new
                {
                    BlogTagId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogTagTag", x => new { x.BlogTagId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BlogTagTag_BlogTag_BlogTagId",
                        column: x => x.BlogTagId,
                        principalTable: "BlogTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlogTagTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogBlogTag_BlogTagId",
                table: "BlogBlogTag",
                column: "BlogTagId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogTagTag_TagId",
                table: "BlogTagTag",
                column: "TagId");
        }
    }
}
