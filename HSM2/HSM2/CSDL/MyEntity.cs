using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSM2.CSDL
{
    public class MyEntity : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MyEntity>(null);
            base.OnModelCreating(modelBuilder);
        }
        public MyEntity() : base("QuanLyCapBa")
        {

        }
        public DbSet<DangNhap> TDangNhaps { get; set; }
        public DbSet<Diem> TDiems { get; set; }
        public DbSet<GiaoVien> TGiaoViens { get; set; }
        public DbSet<HocSinh> THocSinhs { get; set; }
        public DbSet<MonHoc> TMonHocs { get; set; }
        public DbSet<GiaoVienDayHocSinh> TGiaoVienDayHocSinhs { get; set; }
        public DbSet<LichSuChinhSua> TLichSuChinhSuas { get; set; }
        public DbSet<LoaiDiemCuaTungMon> TLoaiDiemCuaTungMons { get; set; }
        public DbSet<LuuTruDiemHSSua> TLuuTruDiemHSSuas { get; set; }
        public DbSet<LuuTruDiemHSXoa> TLuuTruDiemHSXoas { get; set; }
        public DbSet<LuuTruHSSua> TLuuTruHSSuas { get; set; }
        public DbSet<LuuTruHSXoa> TLuuTruHSXoas { get; set; }
        public DbSet<LuuTruLoaiDiemHSSua> TLuuTruLoaiDiemHSSuas { get; set; }
        public DbSet<LuuTruLoaiDiemHSXoa> TLuuTruLoaiDiemHSXoas { get; set; }
        public DbSet<LuuTruThongTinGVSua> TLuuTruThongTinGVSuas { get; set; }
        public DbSet<DuongDan> TDuongDans { get; set; }
        public DbSet<GhiNhoDangNhap> TGhiNhoDangNhaps { get; set; }
    }
}
