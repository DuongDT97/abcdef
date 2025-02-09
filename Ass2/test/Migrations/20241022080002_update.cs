using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_Foods_FoodMonAnID",
                table: "GioHangs");

            migrationBuilder.DropIndex(
                name: "IX_GioHangs_FoodMonAnID",
                table: "GioHangs");

            migrationBuilder.DropIndex(
                name: "IX_GioHangs_KhachHangID",
                table: "GioHangs");

            migrationBuilder.DropColumn(
                name: "FoodMonAnID",
                table: "GioHangs");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_KhachHangID",
                table: "GioHangs",
                column: "KhachHangID");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_MonAnID",
                table: "GioHangs",
                column: "MonAnID");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_Foods_MonAnID",
                table: "GioHangs",
                column: "MonAnID",
                principalTable: "Foods",
                principalColumn: "MonAnID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GioHangs_Foods_MonAnID",
                table: "GioHangs");

            migrationBuilder.DropIndex(
                name: "IX_GioHangs_KhachHangID",
                table: "GioHangs");

            migrationBuilder.DropIndex(
                name: "IX_GioHangs_MonAnID",
                table: "GioHangs");

            migrationBuilder.AddColumn<int>(
                name: "FoodMonAnID",
                table: "GioHangs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_FoodMonAnID",
                table: "GioHangs",
                column: "FoodMonAnID");

            migrationBuilder.CreateIndex(
                name: "IX_GioHangs_KhachHangID",
                table: "GioHangs",
                column: "KhachHangID",
                unique: true,
                filter: "[KhachHangID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_GioHangs_Foods_FoodMonAnID",
                table: "GioHangs",
                column: "FoodMonAnID",
                principalTable: "Foods",
                principalColumn: "MonAnID");
        }
    }
}
