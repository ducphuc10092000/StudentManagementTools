using StudentManagement.View.Dashboard;
using StudentManagement.View.Login;
using StudentManagement.View.Mark_Manage;
using StudentManagement.View.Report_Manage;
using StudentManagement.View.Student_Manage;
using StudentManagement.View.Summary_Manage;
using StudentManagement.View.Teacher_Manage;
using StudentManagement.ViewModel.Dashboard_Manage_ViewModel;
using StudentManagement.ViewModel.Login_ViewModel;
using StudentManagement.ViewModel.Mark_Manage_ViewModel;
using StudentManagement.ViewModel.Student_Manage_ViewModel;
using StudentManagement.ViewModel.Summary_Manage_ViewModel;
using StudentManagement.ViewModel.Teacher_Manage_ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Chức năng Button chuyển UC
        public enum CHUCNANG
        {
            DashBoard, ManageStudent, ManageTeacher, ManageSubject, ManageMark, ManageClass, ManageSchoolYear, ManageSummary, ManageReport, ManageAccount
        }
        private int _ChucNang;
        public int ChucNang { get => _ChucNang; set { _ChucNang = value; OnPropertyChanged(); } }
        #endregion

        #region Declare Binding Command
        public ICommand QuitCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        public ICommand BtnDashBoardCommand { get; set; }
        public ICommand BtnManageStudentCommand { get; set; }
        public ICommand BtnManageTeacherCommand { get; set; }
        public ICommand BtnManageSubjectCommand { get; set; }
        public ICommand BtnManageMarkCommand { get; set; }
        public ICommand BtnManageClassCommand { get; set; }
        public ICommand BtnManageSchoolYearCommand { get; set; }
        public ICommand BtnManageSummaryCommand { get; set; }
        public ICommand BtnManageReportCommand { get; set; }
        public ICommand BtnManageAccountCommand { get; set; }


        #endregion

        public MainViewModel()
        {
            #region Handle Binding Command Swap UserControl

            BtnDashBoardCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.DashBoard;
            });
            BtnManageStudentCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageStudent;
                Student_UC student_UC = new Student_UC();
                var student_UC_DT = student_UC.DataContext as Student_UC_ViewModel;
                student_UC_DT.LoadStudentList();
            });
            BtnManageTeacherCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageTeacher;
                Teacher_UC teacher_UC = new Teacher_UC();
                var teacher_UC_DT = teacher_UC.DataContext as Teacher_UC_ViewModel;
                teacher_UC_DT.LoadTeacherList();
            });
            BtnManageSubjectCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageSubject;
            });
            BtnManageMarkCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageMark;
                Mark_UC mark_UC = new Mark_UC();
                var mark_UC_DT = mark_UC.DataContext as Mark_UC_ViewModel;
                mark_UC_DT.Reset();
            });
            BtnManageClassCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageClass;
            });
            BtnManageSchoolYearCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageSchoolYear;
            });

            BtnManageSummaryCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageSummary;

                Summary_UC summary_UC = new Summary_UC();
                var summary_UC_DT = summary_UC.DataContext as Summary_UC_ViewModel;
                summary_UC_DT.ResetParaSemester();
            });
            BtnManageReportCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageReport;
                Report_UC report_UC = new Report_UC();
                var report_UC_DT = report_UC.DataContext as Summary_UC_ViewModel;
                report_UC_DT.ResetParaSchoolYear();
            });
            BtnManageAccountCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ChucNang = (int)CHUCNANG.ManageAccount;
            });
            #endregion

            #region Handle Binding Command
            QuitCommand = new RelayCommand<MainWindow>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                }
                else
                {
                    return;
                }
            });
            LogOutCommand = new RelayCommand<MainWindow>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    p.Close();
                    Login_WD loginWD = new Login_WD();
                    var loginWD_VM = loginWD.DataContext as Login_WD_ViewModel;
                    loginWD_VM.Load_login_WD();
                    loginWD.ShowDialog();
                }
                else
                {
                    return;
                }
            });
            #endregion
        }
    }
}
