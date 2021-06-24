using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.Model.TEACHER
{
    public class TEACHER
    {
        public GIAO_VIEN giaovien { get; set; }

        public TEACHER()
        {

        }

        public void AddNewTeacher(string ten_giao_vien, string ngay_sinh, string gioi_tinh, string sdt_giao_vien, string email_giao_vien, string dia_chi, string ton_giao, string dan_toc, string quoc_tich, string bo_mon, string avatar,string trinh_do,string so_cmnd)
        {
            giaovien = new GIAO_VIEN();
            giaovien.HO_TEN = ten_giao_vien;
            giaovien.NGAY_SINH = ngay_sinh;
            giaovien.GIOI_TINH = gioi_tinh;
            giaovien.SO_DIEN_THOAI = sdt_giao_vien;
            giaovien.EMAIL = email_giao_vien;
            giaovien.DIA_CHI = dia_chi;
            giaovien.SO_CMND = so_cmnd;
            giaovien.TON_GIAO = DataProvider.Ins.DB.TON_GIAO.Where(x => x.TEN_TON_GIAO == ton_giao).SingleOrDefault();
            giaovien.DAN_TOC = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == dan_toc).SingleOrDefault();
            giaovien.QUOC_TICH = DataProvider.Ins.DB.QUOC_TICH.Where(x => x.TEN_QUOC_TICH == quoc_tich).SingleOrDefault();
            giaovien.BO_MON = DataProvider.Ins.DB.BO_MON.Where(x => x.TEN_BO_MON == bo_mon).SingleOrDefault();
            giaovien.AVATAR = avatar;
            giaovien.TRINH_DO_HOC_VAN = DataProvider.Ins.DB.TRINH_DO_HOC_VAN.Where(x=>x.TEN_TDHV == trinh_do).SingleOrDefault();

            DataProvider.Ins.DB.GIAO_VIEN.Add(giaovien);
            DataProvider.Ins.DB.SaveChanges();

            MessageBox.Show("Thêm thông tin giáo viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void EditTeacher(int ma_giao_vien, string ten_giao_vien, string ngay_sinh, string gioi_tinh, string sdt_giao_vien, string email_giao_vien, string dia_chi, string ton_giao, string dan_toc,string quoc_tich, string bo_mon, string avatar, string trinh_do, string so_cmnd)
        {
            giaovien = DataProvider.Ins.DB.GIAO_VIEN.Where(x => x.MA_GIAO_VIEN == ma_giao_vien).SingleOrDefault();
            giaovien.HO_TEN = ten_giao_vien;
            giaovien.EMAIL = email_giao_vien;
            giaovien.GIOI_TINH = gioi_tinh;
            giaovien.NGAY_SINH = ngay_sinh;
            giaovien.SO_CMND = so_cmnd;
            giaovien.BO_MON = DataProvider.Ins.DB.BO_MON.Where(x => x.TEN_BO_MON == bo_mon).SingleOrDefault();
            giaovien.DAN_TOC = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == dan_toc).SingleOrDefault();
            giaovien.TON_GIAO = DataProvider.Ins.DB.TON_GIAO.Where(x => x.TEN_TON_GIAO == ton_giao).SingleOrDefault();
            giaovien.QUOC_TICH = DataProvider.Ins.DB.QUOC_TICH.Where(x => x.TEN_QUOC_TICH == quoc_tich).SingleOrDefault();
            giaovien.TRINH_DO_HOC_VAN = DataProvider.Ins.DB.TRINH_DO_HOC_VAN.Where(x => x.TEN_TDHV == trinh_do).SingleOrDefault();
            giaovien.SO_DIEN_THOAI = sdt_giao_vien;
            giaovien.DIA_CHI = dia_chi;
            giaovien.AVATAR = avatar;
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Chỉnh sửa thông tin giáo viên thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
