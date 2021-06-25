using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.Model.CLASS
{
    public class CLASS
    {
        public LOP lop { get; set; }

        public string si_so { get; set; }

        public CLASS()
        {

        }

        public void AddNewClass(string ClassName, string Grade, int MaxQuantityStudent, string SchoolYear, GIAO_VIEN selectedTeacher, ObservableCollection<HOC_SINH> studentList)
        {
            lop = new LOP();
            lop.SI_SO = studentList.Count();
            lop.TEN_LOP = ClassName;
            lop.GIAO_VIEN1 = selectedTeacher;
            lop.KHOI_LOP = DataProvider.Ins.DB.KHOI_LOP.Where(x => x.TEN_KHOI_LOP == Grade).SingleOrDefault();
            lop.SI_SO_TOI_DA = MaxQuantityStudent;
            lop.NAM_HOC = DataProvider.Ins.DB.NAM_HOC.Where(x => x.TEN_NAM_HOC == SchoolYear).SingleOrDefault();
           
            DataProvider.Ins.DB.LOPs.Add(lop);
            DataProvider.Ins.DB.SaveChanges();


            ObservableCollection<HOC_KY> hockylist_thisSchoolYear = new ObservableCollection<HOC_KY>(DataProvider.Ins.DB.HOC_KY.Where(x => x.MA_NAM_HOC == lop.MA_NAM_HOC));

            ObservableCollection<MON_HOC> monhocList = new ObservableCollection<MON_HOC>(DataProvider.Ins.DB.MON_HOC.Where(x => x.MA_KHOI_LOP == lop.MA_KHOI_LOP));


            foreach (var item in studentList)
            {
                CLASS_STUDENT_DETAIL class_Student_Detail = new CLASS_STUDENT_DETAIL();
                class_Student_Detail.AddNewClassStudentDetail(lop.MA_LOP, item.MA_HOC_SINH);

                //Chạy list để tạo QUÁ TRÌNH HỌC _ HỌC KỲ
                foreach(var hocky in hockylist_thisSchoolYear)
                {
                    QUA_TRINH_HOC_HOC_KY tempQTHHK = new QUA_TRINH_HOC_HOC_KY();
                    tempQTHHK.LOP = lop;
                    tempQTHHK.HOC_SINH = item;
                    tempQTHHK.HOC_KY = hocky;

                    DataProvider.Ins.DB.QUA_TRINH_HOC_HOC_KY.Add(tempQTHHK);
                    DataProvider.Ins.DB.SaveChanges();

                    //Chạy list để tạo QUÁ TRÌNH HỌC _ MÔN HỌC
                    foreach (var monhoc in monhocList)
                    {
                        QUA_TRINH_HOC_MON_HOC tempQTHMH = new QUA_TRINH_HOC_MON_HOC();
                        tempQTHMH.QUA_TRINH_HOC_HOC_KY = tempQTHHK;
                        tempQTHMH.MON_HOC = monhoc;

                        DataProvider.Ins.DB.QUA_TRINH_HOC_MON_HOC.Add(tempQTHMH);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }    
            }    
            MessageBox.Show("Thêm lớp thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void EditClass(int ClassID, string ClassName, string Grade, int MaxQuantityStudent, string SchoolYear, GIAO_VIEN selectedTeacher, ObservableCollection<HOC_SINH> studentList)
        {
            lop = DataProvider.Ins.DB.LOPs.Where(x => x.MA_LOP == ClassID).SingleOrDefault();
            if(selectedTeacher == null)
            {
                if(lop.GIAO_VIEN != null)
                {
                    lop.GIAO_VIEN1.DA_CHU_NHIEM = Convert.ToBoolean(0);
                    lop.MA_GVCN = null;
                    lop.GIAO_VIEN = null;
                    DataProvider.Ins.DB.SaveChanges();
                }    
            }    
            else
            {
                lop.GIAO_VIEN1 = selectedTeacher;
                lop.GIAO_VIEN1.DA_CHU_NHIEM = Convert.ToBoolean(1);
            }    
            lop.TEN_LOP = ClassName;
            lop.KHOI_LOP = DataProvider.Ins.DB.KHOI_LOP.Where(x => x.TEN_KHOI_LOP == Grade).SingleOrDefault();
            lop.SI_SO_TOI_DA = MaxQuantityStudent;
            lop.NAM_HOC = DataProvider.Ins.DB.NAM_HOC.Where(x => x.TEN_NAM_HOC == SchoolYear).SingleOrDefault();
            lop.SI_SO = studentList.Count();

            

            //Xoá chi tiết LOP_HOCSINH cũ
            ObservableCollection<CT_LOP_HOC_SINH> class_Student_Detail = new ObservableCollection<CT_LOP_HOC_SINH>(DataProvider.Ins.DB.CT_LOP_HOC_SINH.Where(x => x.MA_LOP == ClassID));
            foreach(var item in class_Student_Detail)
            {
                HOC_SINH tempHocSinh = new HOC_SINH();
                tempHocSinh = DataProvider.Ins.DB.HOC_SINH.Where(x => x.MA_HOC_SINH == item.MA_HOC_SINH).SingleOrDefault();
                tempHocSinh.DA_CO_LOP_HOC = Convert.ToBoolean(0);
                DataProvider.Ins.DB.SaveChanges();

                DataProvider.Ins.DB.CT_LOP_HOC_SINH.Remove(item);
                DataProvider.Ins.DB.SaveChanges();
            }

            //Lấy list học kỳ
            ObservableCollection<HOC_KY> hockylist_thisSchoolYear = new ObservableCollection<HOC_KY>(DataProvider.Ins.DB.HOC_KY.Where(x => x.MA_NAM_HOC == lop.MA_NAM_HOC));

            //Lấy list môn học 
            ObservableCollection<MON_HOC> monhocList = new ObservableCollection<MON_HOC>(DataProvider.Ins.DB.MON_HOC.Where(x => x.MA_KHOI_LOP == lop.MA_KHOI_LOP));


            //Tạo chi tiết LOP_HOC_SINH mới
            foreach (var item in studentList)
            {
                HOC_SINH tempHocSinh = new HOC_SINH();
                tempHocSinh = DataProvider.Ins.DB.HOC_SINH.Where(x => x.MA_HOC_SINH == item.MA_HOC_SINH).SingleOrDefault();
                tempHocSinh.DA_CO_LOP_HOC = Convert.ToBoolean(1);
                DataProvider.Ins.DB.SaveChanges();

                CLASS_STUDENT_DETAIL tempclass_Student_Detail = new CLASS_STUDENT_DETAIL();
                tempclass_Student_Detail.AddNewClassStudentDetail(lop.MA_LOP, item.MA_HOC_SINH);

                //Tạo quá trình học _ học kỳ
                foreach (var hocky in hockylist_thisSchoolYear)
                {
                    QUA_TRINH_HOC_HOC_KY tempQTHHK = new QUA_TRINH_HOC_HOC_KY();
                    tempQTHHK.LOP = lop;
                    tempQTHHK.HOC_SINH = item;
                    tempQTHHK.HOC_KY = hocky;

                    if (DataProvider.Ins.DB.QUA_TRINH_HOC_HOC_KY.Where(x => x.LOP.MA_LOP == tempQTHHK.LOP.MA_LOP && x.HOC_SINH.MA_HOC_SINH == tempQTHHK.HOC_SINH.MA_HOC_SINH && x.HOC_KY.MA_HOC_KY == tempQTHHK.HOC_KY.MA_HOC_KY).Count() != 0)
                    {
                        return;
                    }

                    DataProvider.Ins.DB.QUA_TRINH_HOC_HOC_KY.Add(tempQTHHK);
                    DataProvider.Ins.DB.SaveChanges();

                    //Chạy list để tạo QUÁ TRÌNH HỌC _ MÔN HỌC
                    foreach (var monhoc in monhocList)
                    {
                        QUA_TRINH_HOC_MON_HOC tempQTHMH = new QUA_TRINH_HOC_MON_HOC();
                        tempQTHMH.QUA_TRINH_HOC_HOC_KY = tempQTHHK;
                        tempQTHMH.MON_HOC = monhoc;

                        DataProvider.Ins.DB.QUA_TRINH_HOC_MON_HOC.Add(tempQTHMH);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                }
            }

            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Chỉnh sửa thông tin lớp thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
