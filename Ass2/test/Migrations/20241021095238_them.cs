using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test.Migrations
{
    /// <inheritdoc />
    public partial class them : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    MonAnID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.MonAnID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    KhachHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhauHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ho = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.KhachHangID);
                });

            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    ComboID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiCombo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Monawnid = table.Column<int>(type: "int", nullable: true),
                    FoodMonAnID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.ComboID);
                    table.ForeignKey(
                        name: "FK_Combos_Foods_FoodMonAnID",
                        column: x => x.FoodMonAnID,
                        principalTable: "Foods",
                        principalColumn: "MonAnID");
                });

            migrationBuilder.CreateTable(
                name: "GioHangs",
                columns: table => new
                {
                    GioHangId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhachHangID = table.Column<int>(type: "int", nullable: true),
                    MonAnID = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DaThanhToan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FoodMonAnID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHangs", x => x.GioHangId);
                    table.ForeignKey(
                        name: "FK_GioHangs_Foods_FoodMonAnID",
                        column: x => x.FoodMonAnID,
                        principalTable: "Foods",
                        principalColumn: "MonAnID");
                    table.ForeignKey(
                        name: "FK_GioHangs_Users_KhachHangID",
                        column: x => x.KhachHangID,
                        principalTable: "Users",
                        principalColumn: "KhachHangID");
                });

            migrationBuilder.CreateTable(
                name: "Donhangs",
                columns: table => new
                {
                    DonHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trangthai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idgiohang = table.Column<int>(type: "int", nullable: true),
                    GioHangId = table.Column<int>(type: "int", nullable: true),
                    Idfood = table.Column<int>(type: "int", nullable: false),
                    FoodMonAnID = table.Column<int>(type: "int", nullable: true),
                    UserKhachHangID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donhangs", x => x.DonHangID);
                    table.ForeignKey(
                        name: "FK_Donhangs_Foods_FoodMonAnID",
                        column: x => x.FoodMonAnID,
                        principalTable: "Foods",
                        principalColumn: "MonAnID");
                    table.ForeignKey(
                        name: "FK_Donhangs_GioHangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "GioHangs",
                        principalColumn: "GioHangId");
                    table.ForeignKey(
                        name: "FK_Donhangs_Users_UserKhachHangID",
                        column: x => x.UserKhachHangID,
                        principalTable: "Users",
                        principalColumn: "KhachHangID");
                });

            migrationBuilder.CreateTable(
                name: "Ngansaches",
                columns: table => new
                {
                    NgansachID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    TongDoanhThu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongChiPhi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoiNhuan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GioHangId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ngansaches", x => x.NgansachID);
                    table.ForeignKey(
                        name: "FK_Ngansaches_GioHangs_GioHangId",
                        column: x => x.GioHangId,
                        principalTable: "GioHangs",
                        principalColumn: "GioHangId");
                });

            migrationBuilder.CreateTable(
                name: "Hoadons",
                columns: table => new
                {
                    HoaDonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonHangID = table.Column<int>(type: "int", nullable: true),
                    NgayThanhToan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hoadons", x => x.HoaDonID);
                    table.ForeignKey(
                        name: "FK_Hoadons_Donhangs_DonHangID",
                        column: x => x.DonHangID,
                        principalTable: "Donhangs",
                        principalColumn: "DonHangID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Combos_FoodMonAnID",
                table: "Combos",
                column: "FoodMonAnID");

            migrationBuilder.CreateIndex(
                name: "IX_Donhangs_FoodMonAnID",
                table: "Donhangs",
                column: "FoodMonAnID");

            migrationBuilder.CreateIndex(
                name: "IX_Donhangs_GioHangId",
                table: "Donhangs",
                column: "GioHangId");

            migrationBuilder.CreateIndex(
                name: "IX_Donhangs_UserKhachHangID",
                table: "Donhangs",
                column: "UserKhachHangID");

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

            migrationBuilder.CreateIndex(
                name: "IX_Hoadons_DonHangID",
                table: "Hoadons",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX_Ngansaches_GioHangId",
                table: "Ngansaches",
                column: "GioHangId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "Hoadons");

            migrationBuilder.DropTable(
                name: "Ngansaches");

            migrationBuilder.DropTable(
                name: "Donhangs");

            migrationBuilder.DropTable(
                name: "GioHangs");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
