using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel.SchoolYear_Manage_ViewModel
{
    public class AddNewSchoolYear_WD_ViewModel : BaseViewModel
    {
        public ICommand QuitCommand { get; set; }
        public ICommand AddNewSchoolYear_Command { get; set; }

        private string _StartYear;
        public string StartYear { get => _StartYear; set { _StartYear = value; OnPropertyChanged(); } }

        private string _EndYear;
        public string EndYear { get => _EndYear; set { _EndYear = value; OnPropertyChanged(); } }
        public AddNewSchoolYear_WD_ViewModel()
        {
            ResetTextbox();
            QuitCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát", "Thông báo", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                }
                else
                {
                    return;
                }
            });
            AddNewSchoolYear_Command = new RelayCommand<Window>((p) =>
            {
                return true;
            }, (p) =>
            {
                int startYear = new int();
                int endYear = new int();
                if(!int.TryParse(StartYear,out startYear))
                {
                    MessageBox.Show("Năm bắt đầu không phải là số! Xin nhập lại","Thông báo",MessageBoxButton.OK,MessageBoxImage.Error);
                    return;
                }
                if (!int.TryParse(EndYear, out endYear))
                {
                    MessageBox.Show("Năm kết thúc không phải là số! Xin nhập lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if(endYear - startYear != 1)
                {
                    MessageBox.Show("Năm kết thúc cách năm bắt đầu 1 năm! Xin nhập lại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }    

                NAM_HOC tempNamHoc = new NAM_HOC();
                tempNamHoc.NAM_BAT_DAU = startYear;
                tempNamHoc.NAM_KET_THUC = endYear;
                tempNamHoc.TEN_NAM_HOC = StartYear +"-"+ EndYear;
                DataProvider.Ins.DB.NAM_HOC.Add(tempNamHoc);
                DataProvider.Ins.DB.SaveChanges();

                HOC_KY tempHK1 = new HOC_KY();
                tempHK1.TEN_HOC_KY = "Học kỳ 1";
                tempHK1.MA_NAM_HOC = tempNamHoc.MA_NAM_HOC;
                tempHK1.NGAY_BAT_DAU = "01/01/0001";
                tempHK1.NGAY_KET_THUC = "01/01/0001";

                HOC_KY tempHK2 = new HOC_KY();
                tempHK2.TEN_HOC_KY = "Học kỳ 2";
                tempHK2.MA_NAM_HOC = tempNamHoc.MA_NAM_HOC;
                tempHK2.NGAY_BAT_DAU = "01/01/0001";
                tempHK2.NGAY_KET_THUC = "01/01/0001";

                DataProvider.Ins.DB.HOC_KY.Add(tempHK1);
                DataProvider.Ins.DB.SaveChanges();
                DataProvider.Ins.DB.HOC_KY.Add(tempHK2);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Thêm mới năm học thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Close();
            });
        }

        public void ResetTextbox()
        {
            StartYear = "";
            EndYear = "";
        }
    }

}
