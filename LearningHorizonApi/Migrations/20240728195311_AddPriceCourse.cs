using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningHorizonApi.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "coursePrice",
                table: "Courses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "coursePrice",
                table: "Courses");
        }
    }
}
