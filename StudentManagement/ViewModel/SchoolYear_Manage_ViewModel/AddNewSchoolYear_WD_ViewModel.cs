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
        }

        public void ResetTextbox()
        {

        }
    }

}
