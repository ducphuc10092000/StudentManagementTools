using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model.CLASS
{
    public class CLASS_STUDENT_DETAIL
    {
        public CT_LOP_HOC_SINH cT_LOP_HOC_SINH { get; set; }

        public CLASS_STUDENT_DETAIL()
        {

        }

        public void AddNewClassStudentDetail(int classID, int studentID)
        {
            cT_LOP_HOC_SINH = new CT_LOP_HOC_SINH();
            cT_LOP_HOC_SINH.LOP= DataProvider.Ins.DB.LOPs.Where(x => x.MA_LOP == classID).SingleOrDefault();
            cT_LOP_HOC_SINH.HOC_SINH = DataProvider.Ins.DB.HOC_SINH.Where(x => x.MA_HOC_SINH == studentID).SingleOrDefault();

            
            DataProvider.Ins.DB.CT_LOP_HOC_SINH.Add(cT_LOP_HOC_SINH);
            DataProvider.Ins.DB.SaveChanges();

            HOC_SINH temp_Hocsinh = new HOC_SINH();
            temp_Hocsinh = DataProvider.Ins.DB.HOC_SINH.Where(x => x.MA_HOC_SINH == studentID).SingleOrDefault();
            temp_Hocsinh.LOP = DataProvider.Ins.DB.LOPs.Where(x => x.MA_LOP == classID).SingleOrDefault();
            DataProvider.Ins.DB.SaveChanges();
        }
    }
}
