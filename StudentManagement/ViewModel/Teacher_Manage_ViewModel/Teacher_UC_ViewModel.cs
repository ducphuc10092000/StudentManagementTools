using StudentManagement.Model;
using StudentManagement.Model.TEACHER;
using StudentManagement.View.Teacher_Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel.Teacher_Manage_ViewModel
{
    public class Teacher_UC_ViewModel : BaseViewModel
    {
        #region Binding TEACHER_UC
        private ObservableCollection<GIAO_VIEN> _TEACHERLIST;
        public ObservableCollection<GIAO_VIEN> TEACHERLIST { get => _TEACHERLIST; set { _TEACHERLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<TEACHER> _TEACHERLISTDTG;
        public ObservableCollection<TEACHER> TEACHERLISTDTG { get => _TEACHERLISTDTG; set { _TEACHERLISTDTG = value; OnPropertyChanged(); } }

        private TEACHER _SelectedTeacher;
        public TEACHER SelectedTeacher { get => _SelectedTeacher; set { _SelectedTeacher = value; OnPropertyChanged(); } }

        private ObservableCollection<BO_MON> _GROUPSUBJECTLIST;
        public ObservableCollection<BO_MON> GROUPSUBJECTLIST { get => _GROUPSUBJECTLIST; set { _GROUPSUBJECTLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _GroupSubjectListCbb;
        public ObservableCollection<string> GroupSubjectListCbb { get => _GroupSubjectListCbb; set { _GroupSubjectListCbb = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand QuitCommand { get; set; }
        public ICommand DoubleClickSelectTeacherCommand { get; set; }


        public ICommand TeacherFindCommand { get; set; }
        public ICommand TeacherDefaultFilterCommand { get; set; }
        public ICommand Open_AddNewTeacher_WD_Command { get; set; }
        public ICommand Open_EditTeacher_WD_Command { get; set; }
        #endregion

        public Teacher_UC_ViewModel()
        {
            LoadTeacherList();
            LoadCombobox();

            #region Handling command TeacherList_WD
            QuitCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


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
            DoubleClickSelectTeacherCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                if (SelectedTeacher == null)
                {
                    return;
                }
                else
                {
                    p.Close();
                }
            });
            #endregion
            #region Handling command Button TEACHER_UC
            Open_AddNewTeacher_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewTeacher_WD addNewTeacher_WD = new AddNewTeacher_WD();
                var addNewTeacher_WD_VM = addNewTeacher_WD.DataContext as AddNewTeacher_WD_ViewModel;
                addNewTeacher_WD_VM.ResetTextBox();
                addNewTeacher_WD.ShowDialog();
                addNewTeacher_WD.Close();
            });

            Open_EditTeacher_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditTeacher_WD editTeacher_WD = new EditTeacher_WD();
                var editTeacher_WD_DT = editTeacher_WD.DataContext as AddNewTeacher_WD_ViewModel;
                editTeacher_WD_DT.LoadSelectedTeacher(Convert.ToInt32(p));
                editTeacher_WD.ShowDialog();
                editTeacher_WD.Close();
                LoadTeacherList();
            });
            #endregion

        }
        public void LoadTeacherList()
        {
            TEACHERLIST = new ObservableCollection<GIAO_VIEN>(DataProvider.Ins.DB.GIAO_VIEN);
            TEACHERLISTDTG = new ObservableCollection<TEACHER>();

            foreach (var item in TEACHERLIST)
            {
                TEACHER temp_teacher = new TEACHER();

                temp_teacher.giaovien = item;

                TEACHERLISTDTG.Add(temp_teacher);
            }
        }
        public void LoadTeacherListNotHomeroomTeacher()
        {
            TEACHERLIST = new ObservableCollection<GIAO_VIEN>(DataProvider.Ins.DB.GIAO_VIEN.Where(x=>x.DA_CHU_NHIEM == false));
            TEACHERLISTDTG = new ObservableCollection<TEACHER>();

            foreach (var item in TEACHERLIST)
            {
                TEACHER temp_teacher = new TEACHER();

                temp_teacher.giaovien = item;

                TEACHERLISTDTG.Add(temp_teacher);
            }
        }
        public void LoadCombobox()
        {
            GROUPSUBJECTLIST = new ObservableCollection<BO_MON>(DataProvider.Ins.DB.BO_MON);
            GroupSubjectListCbb = new ObservableCollection<string>();

            foreach (var item in GROUPSUBJECTLIST)
            {
                GroupSubjectListCbb.Add(item.TEN_BO_MON);
            }
        }
    }
}
