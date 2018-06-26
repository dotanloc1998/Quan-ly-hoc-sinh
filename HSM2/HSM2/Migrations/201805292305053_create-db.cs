namespace HSM2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DangNhaps",
                c => new
                    {
                        MaTaiKhoan = c.String(nullable: false, maxLength: 128),
                        MatKhau = c.String(),
                        MaPin = c.String(),
                        GiaoVienCuaDangNhap_MaGV = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaTaiKhoan)
                .ForeignKey("dbo.GiaoViens", t => t.GiaoVienCuaDangNhap_MaGV)
                .Index(t => t.GiaoVienCuaDangNhap_MaGV);
            
            CreateTable(
                "dbo.GiaoViens",
                c => new
                    {
                        MaGV = c.String(nullable: false, maxLength: 128),
                        HoTenGV = c.String(),
                        NgaySinhGV = c.DateTime(nullable: false),
                        QueQuanGV = c.String(),
                        DiaChiGV = c.String(),
                        SDT = c.String(),
                        MonDay = c.String(),
                        LopChuNhiem = c.String(),
                        MaMonHocCuaGV_MaMH = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaGV)
                .ForeignKey("dbo.MonHocs", t => t.MaMonHocCuaGV_MaMH)
                .Index(t => t.MaMonHocCuaGV_MaMH);
            
            CreateTable(
                "dbo.GiaoVienDayHocSinhs",
                c => new
                    {
                        MaCuaGV = c.String(nullable: false, maxLength: 128),
                        MaLopCuaSV = c.String(nullable: false, maxLength: 128),
                        MonMaLopDuocDay = c.String(),
                        KhoaNgoaiGV_MaGV = c.String(maxLength: 128),
                        KhoaNgoaiHS_MaSoHS = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MaCuaGV, t.MaLopCuaSV })
                .ForeignKey("dbo.GiaoViens", t => t.KhoaNgoaiGV_MaGV)
                .ForeignKey("dbo.HocSinhs", t => t.KhoaNgoaiHS_MaSoHS)
                .Index(t => t.KhoaNgoaiGV_MaGV)
                .Index(t => t.KhoaNgoaiHS_MaSoHS);
            
            CreateTable(
                "dbo.HocSinhs",
                c => new
                    {
                        MaSoHS = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        NgaySinh = c.DateTime(nullable: false),
                        XLHocLuc = c.String(),
                        XLHanhKiem = c.String(),
                        QueQuan = c.String(),
                        LopCuaHS = c.String(),
                        DiemTBCuaHS = c.Double(nullable: false),
                        MaGVCuaHS_MaGV = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaSoHS)
                .ForeignKey("dbo.GiaoViens", t => t.MaGVCuaHS_MaGV)
                .Index(t => t.MaGVCuaHS_MaGV);
            
            CreateTable(
                "dbo.MonHocs",
                c => new
                    {
                        MaMH = c.String(nullable: false, maxLength: 128),
                        TenMH = c.String(),
                    })
                .PrimaryKey(t => t.MaMH);
            
            CreateTable(
                "dbo.Diems",
                c => new
                    {
                        MaDiem = c.String(nullable: false, maxLength: 128),
                        SoDiem = c.Double(nullable: false),
                        MaHSCuaDiemA = c.String(),
                        MaHSCuaDiem_MaSoHS = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaDiem)
                .ForeignKey("dbo.HocSinhs", t => t.MaHSCuaDiem_MaSoHS)
                .Index(t => t.MaHSCuaDiem_MaSoHS);
            
            CreateTable(
                "dbo.DuongDans",
                c => new
                    {
                        MaDuongDan = c.String(nullable: false, maxLength: 128),
                        DuongDanDenFile = c.String(),
                    })
                .PrimaryKey(t => t.MaDuongDan);
            
            CreateTable(
                "dbo.GhiNhoDangNhaps",
                c => new
                    {
                        MaDangNhapTruoc = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.MaDangNhapTruoc);
            
            CreateTable(
                "dbo.LichSuChinhSuas",
                c => new
                    {
                        MaChinhSua = c.String(nullable: false, maxLength: 128),
                        ThoiGianChinhSua = c.DateTime(nullable: false),
                        MaGVSua = c.String(),
                    })
                .PrimaryKey(t => t.MaChinhSua);
            
            CreateTable(
                "dbo.LoaiDiemCuaTungMons",
                c => new
                    {
                        MaLoaiDiem = c.String(nullable: false, maxLength: 128),
                        SoDiem = c.Double(nullable: false),
                        MaDiemCuaLoaiDiem = c.String(),
                        KhoaNgoaiDiemCuaLoaiDiem_MaDiem = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaLoaiDiem)
                .ForeignKey("dbo.Diems", t => t.KhoaNgoaiDiemCuaLoaiDiem_MaDiem)
                .Index(t => t.KhoaNgoaiDiemCuaLoaiDiem_MaDiem);
            
            CreateTable(
                "dbo.LuuTruDiemHSSuas",
                c => new
                    {
                        MaDiemSua = c.String(nullable: false, maxLength: 128),
                        SoDiemSua = c.Double(nullable: false),
                        MaHSCuaDiemSua = c.String(),
                        MaHSSuaCuaDiemSua_MaSua = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaDiemSua)
                .ForeignKey("dbo.LuuTruHSSuas", t => t.MaHSSuaCuaDiemSua_MaSua)
                .Index(t => t.MaHSSuaCuaDiemSua_MaSua);
            
            CreateTable(
                "dbo.LuuTruHSSuas",
                c => new
                    {
                        MaSua = c.String(nullable: false, maxLength: 128),
                        MaSoHSSua = c.String(),
                        HoTenSua = c.String(),
                        DiaChiSua = c.String(),
                        NgaySinhSua = c.DateTime(nullable: false),
                        XLHocLucSua = c.String(),
                        XLHanhKiemSua = c.String(),
                        QueQuanSua = c.String(),
                        LopCuaHSSua = c.String(),
                        DiemTBCuaHSSua = c.Double(nullable: false),
                        MaChinhSuaCuaLuuTru = c.String(),
                        KhoaNgoaiCuaLuuTru_MaChinhSua = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaSua)
                .ForeignKey("dbo.LichSuChinhSuas", t => t.KhoaNgoaiCuaLuuTru_MaChinhSua)
                .Index(t => t.KhoaNgoaiCuaLuuTru_MaChinhSua);
            
            CreateTable(
                "dbo.LuuTruDiemHSXoas",
                c => new
                    {
                        MaDiemXoa = c.String(nullable: false, maxLength: 128),
                        SoDiemXoa = c.Double(nullable: false),
                        MaHSCuaDiemXoa = c.String(),
                        KhoaNgoaiCuaLuuTruDiem_MaSoHSXoa = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaDiemXoa)
                .ForeignKey("dbo.LuuTruHSXoas", t => t.KhoaNgoaiCuaLuuTruDiem_MaSoHSXoa)
                .Index(t => t.KhoaNgoaiCuaLuuTruDiem_MaSoHSXoa);
            
            CreateTable(
                "dbo.LuuTruHSXoas",
                c => new
                    {
                        MaSoHSXoa = c.String(nullable: false, maxLength: 128),
                        HoTenXoa = c.String(),
                        DiaChiXoa = c.String(),
                        NgaySinhXoa = c.DateTime(nullable: false),
                        XLHocLucXoa = c.String(),
                        XLHanhKiemXoa = c.String(),
                        QueQuanXoa = c.String(),
                        LopCuaHSXoa = c.String(),
                        DiemTBCuaHSXoa = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaSoHSXoa);
            
            CreateTable(
                "dbo.LuuTruLoaiDiemHSSuas",
                c => new
                    {
                        MaLoaiDiemSua = c.String(nullable: false, maxLength: 128),
                        SoDiemSua = c.Double(nullable: false),
                        MaDiemCuaLoaiDiemSua = c.String(),
                        KhoaNgoaiDiemCuaLoaiDiemSua_MaDiemSua = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaLoaiDiemSua)
                .ForeignKey("dbo.LuuTruDiemHSSuas", t => t.KhoaNgoaiDiemCuaLoaiDiemSua_MaDiemSua)
                .Index(t => t.KhoaNgoaiDiemCuaLoaiDiemSua_MaDiemSua);
            
            CreateTable(
                "dbo.LuuTruLoaiDiemHSXoas",
                c => new
                    {
                        MaLoaiDiemXoa = c.String(nullable: false, maxLength: 128),
                        SoDiemXoa = c.Double(nullable: false),
                        MaDiemCuaLoaiDiemXoa = c.String(),
                        KhoaNgoaiCuaLuuLoaiDiem_MaDiemXoa = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaLoaiDiemXoa)
                .ForeignKey("dbo.LuuTruDiemHSXoas", t => t.KhoaNgoaiCuaLuuLoaiDiem_MaDiemXoa)
                .Index(t => t.KhoaNgoaiCuaLuuLoaiDiem_MaDiemXoa);
            
            CreateTable(
                "dbo.LuuTruThongTinGVSuas",
                c => new
                    {
                        MaSuaChuaThongTinGV = c.String(nullable: false, maxLength: 128),
                        MaGVSua = c.String(),
                        HoTenGVSua = c.String(),
                        NgaySinhGVSua = c.DateTime(nullable: false),
                        QueQuanGVSua = c.String(),
                        DiaChiGVSua = c.String(),
                        SDTSua = c.String(),
                        MonDaySua = c.String(),
                        LopChuNhiemSua = c.String(),
                        NgayThangSua = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaSuaChuaThongTinGV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LuuTruLoaiDiemHSXoas", "KhoaNgoaiCuaLuuLoaiDiem_MaDiemXoa", "dbo.LuuTruDiemHSXoas");
            DropForeignKey("dbo.LuuTruLoaiDiemHSSuas", "KhoaNgoaiDiemCuaLoaiDiemSua_MaDiemSua", "dbo.LuuTruDiemHSSuas");
            DropForeignKey("dbo.LuuTruDiemHSXoas", "KhoaNgoaiCuaLuuTruDiem_MaSoHSXoa", "dbo.LuuTruHSXoas");
            DropForeignKey("dbo.LuuTruDiemHSSuas", "MaHSSuaCuaDiemSua_MaSua", "dbo.LuuTruHSSuas");
            DropForeignKey("dbo.LuuTruHSSuas", "KhoaNgoaiCuaLuuTru_MaChinhSua", "dbo.LichSuChinhSuas");
            DropForeignKey("dbo.LoaiDiemCuaTungMons", "KhoaNgoaiDiemCuaLoaiDiem_MaDiem", "dbo.Diems");
            DropForeignKey("dbo.Diems", "MaHSCuaDiem_MaSoHS", "dbo.HocSinhs");
            DropForeignKey("dbo.DangNhaps", "GiaoVienCuaDangNhap_MaGV", "dbo.GiaoViens");
            DropForeignKey("dbo.GiaoViens", "MaMonHocCuaGV_MaMH", "dbo.MonHocs");
            DropForeignKey("dbo.HocSinhs", "MaGVCuaHS_MaGV", "dbo.GiaoViens");
            DropForeignKey("dbo.GiaoVienDayHocSinhs", "KhoaNgoaiHS_MaSoHS", "dbo.HocSinhs");
            DropForeignKey("dbo.GiaoVienDayHocSinhs", "KhoaNgoaiGV_MaGV", "dbo.GiaoViens");
            DropIndex("dbo.LuuTruLoaiDiemHSXoas", new[] { "KhoaNgoaiCuaLuuLoaiDiem_MaDiemXoa" });
            DropIndex("dbo.LuuTruLoaiDiemHSSuas", new[] { "KhoaNgoaiDiemCuaLoaiDiemSua_MaDiemSua" });
            DropIndex("dbo.LuuTruDiemHSXoas", new[] { "KhoaNgoaiCuaLuuTruDiem_MaSoHSXoa" });
            DropIndex("dbo.LuuTruHSSuas", new[] { "KhoaNgoaiCuaLuuTru_MaChinhSua" });
            DropIndex("dbo.LuuTruDiemHSSuas", new[] { "MaHSSuaCuaDiemSua_MaSua" });
            DropIndex("dbo.LoaiDiemCuaTungMons", new[] { "KhoaNgoaiDiemCuaLoaiDiem_MaDiem" });
            DropIndex("dbo.Diems", new[] { "MaHSCuaDiem_MaSoHS" });
            DropIndex("dbo.HocSinhs", new[] { "MaGVCuaHS_MaGV" });
            DropIndex("dbo.GiaoVienDayHocSinhs", new[] { "KhoaNgoaiHS_MaSoHS" });
            DropIndex("dbo.GiaoVienDayHocSinhs", new[] { "KhoaNgoaiGV_MaGV" });
            DropIndex("dbo.GiaoViens", new[] { "MaMonHocCuaGV_MaMH" });
            DropIndex("dbo.DangNhaps", new[] { "GiaoVienCuaDangNhap_MaGV" });
            DropTable("dbo.LuuTruThongTinGVSuas");
            DropTable("dbo.LuuTruLoaiDiemHSXoas");
            DropTable("dbo.LuuTruLoaiDiemHSSuas");
            DropTable("dbo.LuuTruHSXoas");
            DropTable("dbo.LuuTruDiemHSXoas");
            DropTable("dbo.LuuTruHSSuas");
            DropTable("dbo.LuuTruDiemHSSuas");
            DropTable("dbo.LoaiDiemCuaTungMons");
            DropTable("dbo.LichSuChinhSuas");
            DropTable("dbo.GhiNhoDangNhaps");
            DropTable("dbo.DuongDans");
            DropTable("dbo.Diems");
            DropTable("dbo.MonHocs");
            DropTable("dbo.HocSinhs");
            DropTable("dbo.GiaoVienDayHocSinhs");
            DropTable("dbo.GiaoViens");
            DropTable("dbo.DangNhaps");
        }
    }
}
