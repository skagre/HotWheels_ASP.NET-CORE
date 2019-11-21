using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HotWheels.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHangDb",
                columns: table => new
                {
                    ID_DonHang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaChi = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HoVaTen = table.Column<string>(nullable: true),
                    NgayDat = table.Column<DateTime>(nullable: false),
                    SoDienThoai = table.Column<string>(nullable: true),
                    TongTien = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangDb", x => x.ID_DonHang);
                });

            migrationBuilder.CreateTable(
                name: "GioHang",
                columns: table => new
                {
                    ID_GioHang = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GioHang", x => x.ID_GioHang);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoanDb",
                columns: table => new
                {
                    ID_TaiKhoan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Password = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoanDb", x => x.ID_TaiKhoan);
                });

            migrationBuilder.CreateTable(
                name: "ThuongHieuDb",
                columns: table => new
                {
                    ID_ThuongHieu = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TenThuongHieu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThuongHieuDb", x => x.ID_ThuongHieu);
                });

            migrationBuilder.CreateTable(
                name: "SanPhamDb",
                columns: table => new
                {
                    ID_SanPham = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anh = table.Column<string>(nullable: true),
                    ChatLieu = table.Column<string>(nullable: true),
                    DonGia = table.Column<decimal>(nullable: false),
                    ID_ThuongHieu = table.Column<int>(nullable: false),
                    MoTa = table.Column<string>(nullable: true),
                    TenSanPham = table.Column<string>(nullable: true),
                    TyLe = table.Column<string>(nullable: true),
                    XuatXu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPhamDb", x => x.ID_SanPham);
                    table.ForeignKey(
                        name: "FK_SanPhamDb_ThuongHieuDb_ID_ThuongHieu",
                        column: x => x.ID_ThuongHieu,
                        principalTable: "ThuongHieuDb",
                        principalColumn: "ID_ThuongHieu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTDonHangDb",
                columns: table => new
                {
                    ID_CTDonHang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Gia = table.Column<decimal>(nullable: false),
                    ID_DonHang = table.Column<int>(nullable: false),
                    ID_SanPham = table.Column<int>(nullable: false),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTDonHangDb", x => x.ID_CTDonHang);
                    table.ForeignKey(
                        name: "FK_CTDonHangDb_DonHangDb_ID_DonHang",
                        column: x => x.ID_DonHang,
                        principalTable: "DonHangDb",
                        principalColumn: "ID_DonHang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTDonHangDb_SanPhamDb_ID_SanPham",
                        column: x => x.ID_SanPham,
                        principalTable: "SanPhamDb",
                        principalColumn: "ID_SanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTGioHangDb",
                columns: table => new
                {
                    ID_CTGioHang = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ID_GioHang = table.Column<string>(nullable: true),
                    SanPhamID_SanPham = table.Column<int>(nullable: true),
                    SoLuong = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTGioHangDb", x => x.ID_CTGioHang);
                    table.ForeignKey(
                        name: "FK_CTGioHangDb_GioHang_ID_GioHang",
                        column: x => x.ID_GioHang,
                        principalTable: "GioHang",
                        principalColumn: "ID_GioHang",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CTGioHangDb_SanPhamDb_SanPhamID_SanPham",
                        column: x => x.SanPhamID_SanPham,
                        principalTable: "SanPhamDb",
                        principalColumn: "ID_SanPham",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTDonHangDb_ID_DonHang",
                table: "CTDonHangDb",
                column: "ID_DonHang");

            migrationBuilder.CreateIndex(
                name: "IX_CTDonHangDb_ID_SanPham",
                table: "CTDonHangDb",
                column: "ID_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_CTGioHangDb_ID_GioHang",
                table: "CTGioHangDb",
                column: "ID_GioHang");

            migrationBuilder.CreateIndex(
                name: "IX_CTGioHangDb_SanPhamID_SanPham",
                table: "CTGioHangDb",
                column: "SanPhamID_SanPham");

            migrationBuilder.CreateIndex(
                name: "IX_SanPhamDb_ID_ThuongHieu",
                table: "SanPhamDb",
                column: "ID_ThuongHieu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTDonHangDb");

            migrationBuilder.DropTable(
                name: "CTGioHangDb");

            migrationBuilder.DropTable(
                name: "TaiKhoanDb");

            migrationBuilder.DropTable(
                name: "DonHangDb");

            migrationBuilder.DropTable(
                name: "GioHang");

            migrationBuilder.DropTable(
                name: "SanPhamDb");

            migrationBuilder.DropTable(
                name: "ThuongHieuDb");
        }
    }
}
