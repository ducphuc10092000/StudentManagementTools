using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model.MARK
{
    public class MARK
    {
        public DIEM diem { get; set; }

        public MARK()
        {

        }

        public void AddNewMark(int ma_qt_mon_hoc, int ma_mon_hoc, int ma_loai_diem, double diem_so)
        {
            diem = new DIEM();
            diem.DIEM_SO = diem_so;
            diem.MA_QTMH = ma_qt_mon_hoc;
            diem.MA_MON_HOC = ma_mon_hoc;
            diem.MA_LOAI_DIEM = ma_loai_diem;
            DataProvider.Ins.DB.DIEMs.Add(diem);
            DataProvider.Ins.DB.SaveChanges();
        }

        public void DeleteMark()
        {
            
        }
    }
}
