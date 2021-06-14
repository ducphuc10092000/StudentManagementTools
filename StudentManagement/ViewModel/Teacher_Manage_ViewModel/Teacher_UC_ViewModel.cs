using StudentManagement.Model;
using StudentManagement.Model.TEACHER;
using StudentManagement.View.Teacher_Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace StudentManagement.ViewModel.Teacher_Manage_ViewModel
{
    public class Teacher_UC_ViewModel:BaseViewModel
    {
        #region Binding TEACHER_UC
        private ObservableCollection<GIAO_VIEN> _TEACHERLIST;
        public ObservableCollection<GIAO_VIEN> TEACHERLIST { get => _TEACHERLIST; set { _TEACHERLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<TEACHER> _TEACHERLISTDTG;
        public ObservableCollection<TEACHER> TEACHERLISTDTG { get => _TEACHERLISTDTG; set { _TEACHERLISTDTG = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand TeacherFindCommand { get; set; }
        public ICommand TeacherDefaultFilterCommand { get; set; }
        public ICommand Open_AddNewTeacher_WD_Command { get; set; }
        public ICommand Open_EditTeacher_WD_Command { get; set; }
        #endregion

        public Teacher_UC_ViewModel()
        {
            LoadTeacherList();

            #region Handling command Button TEACHER_UC
            Open_AddNewTeacher_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewTeacher_WD addNewTeacher_WD = new AddNewTeacher_WD();
                var addNewTeacher_WD_VM = addNewTeacher_WD.DataContext as AddNewTeacher_WD_ViewModel;
                //addNewTeacher_WD_VM.ResetTextbox();
                addNewTeacher_WD.ShowDialog();
                addNewTeacher_WD.Close();
            });

            Open_EditTeacher_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditTeacher_WD editTeacher_WD = new EditTeacher_WD();
                var editTeacher_WD_DT = editTeacher_WD.DataContext as EditTeacher_WD_ViewModel;
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
    }
}
