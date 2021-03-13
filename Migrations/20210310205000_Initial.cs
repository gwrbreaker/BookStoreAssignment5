using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAssignment5.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(nullable: false),
                    authorLast = table.Column<string>(nullable: false),
                    authorFirst = table.Column<string>(nullable: false),
                    publisher = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: false),
                    classification = table.Column<string>(nullable: false),
                    category = table.Column<string>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    pages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
