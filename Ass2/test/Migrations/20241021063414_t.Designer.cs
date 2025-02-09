﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Model;

#nullable disable

namespace test.Migrations
{
    [DbContext(typeof(Dbcon))]
    [Migration("20241021063414_t")]
    partial class t
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("test.Model.Combos", b =>
                {
                    b.Property<int>("ComboID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboID"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiCombo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComboID");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("test.Model.Donhang", b =>
                {
                    b.Property<int>("DonHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonHangID"));

                    b.Property<int?>("FoodMonAnID")
                        .HasColumnType("int");

                    b.Property<int>("Idfood")
                        .HasColumnType("int");

                    b.Property<int?>("Idgiohang")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Idkhachhang")
                        .HasColumnType("int");

                    b.Property<DateTime>("Ngay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Trangthai")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonHangID");

                    b.HasIndex("FoodMonAnID");

                    b.HasIndex("Idgiohang")
                        .IsUnique();

                    b.HasIndex("Idkhachhang");

                    b.ToTable("Donhangs");
                });

            modelBuilder.Entity("test.Model.Food", b =>
                {
                    b.Property<int>("MonAnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonAnID"));

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("GioHangId")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Loai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MoTa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TinhTrang")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonAnID");

                    b.HasIndex("GioHangId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("test.Model.GioHang", b =>
                {
                    b.Property<int>("GioHangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GioHangId"));

                    b.Property<string>("DaThanhToan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KhachHangID")
                        .HasColumnType("int");

                    b.Property<int>("MonAnID")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<decimal?>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GioHangId");

                    b.HasIndex("KhachHangID");

                    b.ToTable("GioHangs");
                });

            modelBuilder.Entity("test.Model.Hoadon", b =>
                {
                    b.Property<int>("HoaDonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HoaDonID"));

                    b.Property<int>("DonHangID")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayThanhToan")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TongTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HoaDonID");

                    b.HasIndex("DonHangID")
                        .IsUnique();

                    b.ToTable("Hoadons");
                });

            modelBuilder.Entity("test.Model.Ngansach", b =>
                {
                    b.Property<int>("NgansachID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NgansachID"));

                    b.Property<decimal>("LoiNhuan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Nam")
                        .HasColumnType("int");

                    b.Property<int>("Thang")
                        .HasColumnType("int");

                    b.Property<decimal>("TongChiPhi")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TongDoanhThu")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("NgansachID");

                    b.ToTable("Ngansaches");
                });

            modelBuilder.Entity("test.Model.User", b =>
                {
                    b.Property<int>("KhachHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhachHangID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhauHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenDangNhap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VaiTro")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KhachHangID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("test.Model.Donhang", b =>
                {
                    b.HasOne("test.Model.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodMonAnID");

                    b.HasOne("test.Model.GioHang", "GioHang")
                        .WithOne()
                        .HasForeignKey("test.Model.Donhang", "Idgiohang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test.Model.User", "User")
                        .WithMany("Donhangs")
                        .HasForeignKey("Idkhachhang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("GioHang");

                    b.Navigation("User");
                });

            modelBuilder.Entity("test.Model.Food", b =>
                {
                    b.HasOne("test.Model.GioHang", null)
                        .WithMany("Foods")
                        .HasForeignKey("GioHangId");
                });

            modelBuilder.Entity("test.Model.GioHang", b =>
                {
                    b.HasOne("test.Model.User", "KhachHang")
                        .WithMany("GioHangs")
                        .HasForeignKey("KhachHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhachHang");
                });

            modelBuilder.Entity("test.Model.Hoadon", b =>
                {
                    b.HasOne("test.Model.Donhang", "DonHang")
                        .WithOne()
                        .HasForeignKey("test.Model.Hoadon", "DonHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonHang");
                });

            modelBuilder.Entity("test.Model.GioHang", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("test.Model.User", b =>
                {
                    b.Navigation("Donhangs");

                    b.Navigation("GioHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
