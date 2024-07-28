using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningHorizonApi.Migrations
{
    /// <inheritdoc />
    public partial class addTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    bookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    bookLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bookDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.bookId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseTittle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseCreator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseId);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    lessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lessonTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lessonOrderInCourse = table.Column<int>(type: "int", nullable: false),
                    lessonDuration = table.Column<int>(type: "int", nullable: false),
                    lessonPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lessonLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    courseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.lessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_courseId",
                        column: x => x.courseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_courseId",
                table: "Lessons",
                column: "courseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
