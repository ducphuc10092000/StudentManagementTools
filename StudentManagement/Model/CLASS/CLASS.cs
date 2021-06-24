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

            foreach(var item in studentList)
            {
                CLASS_STUDENT_DETAIL class_Student_Detail = new CLASS_STUDENT_DETAIL();
                class_Student_Detail.AddNewClassStudentDetail(lop.MA_LOP, item.MA_HOC_SINH);
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

            foreach (var item in studentList)
            {
                HOC_SINH tempHocSinh = new HOC_SINH();
                tempHocSinh = DataProvider.Ins.DB.HOC_SINH.Where(x => x.MA_HOC_SINH == item.MA_HOC_SINH).SingleOrDefault();
                tempHocSinh.DA_CO_LOP_HOC = Convert.ToBoolean(1);
                DataProvider.Ins.DB.SaveChanges();
                CLASS_STUDENT_DETAIL tempclass_Student_Detail = new CLASS_STUDENT_DETAIL();
                tempclass_Student_Detail.AddNewClassStudentDetail(lop.MA_LOP, item.MA_HOC_SINH);
            }

            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Chỉnh sửa thông tin lớp thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
