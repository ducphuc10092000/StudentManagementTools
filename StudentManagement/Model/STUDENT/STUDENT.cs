using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.Model.STUDENT
{
    public class STUDENT
    {
        public HOC_SINH hocsinh { get; set; }

        public STUDENT()
        {

        }

        public void AddNewStudent(string ten_hoc_sinh, string gioi_tinh, string ngay_sinh, string dan_toc, string quoc_tich, string ho_ten_cha, string ho_ten_me, string sdt_hoc_sinh, string sdt_phu_huynh, string dia_chi, string avatar)
        {
            hocsinh = new HOC_SINH();
            hocsinh.HO_TEN = ten_hoc_sinh;
            hocsinh.GIOI_TINH = gioi_tinh;
            hocsinh.NGAY_SINH = Convert.ToDateTime(ngay_sinh);
            hocsinh.DAN_TOC = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == dan_toc).SingleOrDefault();
            hocsinh.QUOC_TICH = DataProvider.Ins.DB.QUOC_TICH.Where(x => x.TEN_QUOC_TICH == quoc_tich).SingleOrDefault();
            hocsinh.HO_TEN_CHA = ho_ten_cha;
            hocsinh.HO_TEN_ME = ho_ten_me;
            hocsinh.SO_DIEN_THOAI = sdt_hoc_sinh;
            hocsinh.SDT_PHU_HUYNH = sdt_phu_huynh;
            hocsinh.DIA_CHI = dia_chi;
            hocsinh.AVATAR = avatar;

            DataProvider.Ins.DB.HOC_SINH.Add(hocsinh);
            DataProvider.Ins.DB.SaveChanges();

            MessageBox.Show("Thêm thông tin học sinh thành công!","Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void EditStudent(int ma_hoc_sinh, string ten_hoc_sinh, string gioi_tinh, string ngay_sinh, string dan_toc, string ton_giao, string ho_ten_cha, string ho_ten_me, string sdt_hoc_sinh, string sdt_phu_huynh, string dia_chi, string avatar)
        {
            hocsinh = DataProvider.Ins.DB.HOC_SINH.Where(x => x.MA_HOC_SINH == ma_hoc_sinh).SingleOrDefault();
            hocsinh.HO_TEN = ten_hoc_sinh;
            hocsinh.GIOI_TINH = gioi_tinh;
            hocsinh.NGAY_SINH = Convert.ToDateTime(ngay_sinh);
            hocsinh.DAN_TOC = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == dan_toc).SingleOrDefault();
            hocsinh.TON_GIAO = DataProvider.Ins.DB.TON_GIAO.Where(x => x.TEN_TON_GIAO == ton_giao).SingleOrDefault();
            hocsinh.HO_TEN_CHA = ho_ten_cha;
            hocsinh.HO_TEN_ME = ho_ten_me;
            hocsinh.SO_DIEN_THOAI = sdt_hoc_sinh;
            hocsinh.SDT_PHU_HUYNH = sdt_phu_huynh;
            hocsinh.DIA_CHI = dia_chi;
            hocsinh.AVATAR = avatar;
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Chỉnh sửa thông tin học sinh thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
