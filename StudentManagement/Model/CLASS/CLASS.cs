using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.Model.CLASS
{
    public class CLASS
    {
        public LOP lop { get; set; }

        public CLASS()
        {

        }

        public void AddNewClass()
        {
            lop = new LOP();
           
            DataProvider.Ins.DB.LOPs.Add(lop);
            DataProvider.Ins.DB.SaveChanges();

            MessageBox.Show("Thêm thông tin lớp học thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        public void EditClass()
        {
            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Chỉnh sửa thông tin lớp học thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
