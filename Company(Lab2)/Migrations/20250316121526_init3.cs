using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company_Lab2_.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Courses_CourseId",
                table: "CrsResults");

            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_CrsResults_CrsId",
                table: "CrsResults");

            migrationBuilder.DropIndex(
                name: "IX_CrsResults_CourseId",
                table: "CrsResults");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CrsResults");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Courses_CrsId",
                table: "CrsResults",
                column: "CrsId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrsResults_Courses_CrsId",
                table: "CrsResults");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CrsResults",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_CrsResults_CourseId",
                table: "CrsResults",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_Courses_CourseId",
                table: "CrsResults",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CrsResults_CrsResults_CrsId",
                table: "CrsResults",
                column: "CrsId",
                principalTable: "CrsResults",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
