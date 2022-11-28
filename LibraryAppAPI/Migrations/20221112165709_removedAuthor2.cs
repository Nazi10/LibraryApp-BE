using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryApp.Migrations
{
    public partial class removedAuthor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategoryBookCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookCategoryBookCategory",
                columns: table => new
                {
                    BooksBookId = table.Column<Guid>(type: "uuid", nullable: false),
                    BooksCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriesBookId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriesCategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategoryBookCategory", x => new { x.BooksBookId, x.BooksCategoryId, x.CategoriesBookId, x.CategoriesCategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategoryBookCategory_BookCategories_BooksBookId_BooksCa~",
                        columns: x => new { x.BooksBookId, x.BooksCategoryId },
                        principalTable: "BookCategories",
                        principalColumns: new[] { "BookId", "CategoryId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategoryBookCategory_BookCategories_CategoriesBookId_Ca~",
                        columns: x => new { x.CategoriesBookId, x.CategoriesCategoryId },
                        principalTable: "BookCategories",
                        principalColumns: new[] { "BookId", "CategoryId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoryBookCategory_CategoriesBookId_CategoriesCategor~",
                table: "BookCategoryBookCategory",
                columns: new[] { "CategoriesBookId", "CategoriesCategoryId" });
        }
    }
}
