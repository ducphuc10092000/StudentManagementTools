using StudentManagement.Model;
using StudentManagement.Model.CLASS;
using StudentManagement.Model.STUDENT;
using StudentManagement.Model.TEACHER;
using StudentManagement.View.Class_Manage;
using StudentManagement.View.Student_Manage;
using StudentManagement.View.Teacher_Manage;
using StudentManagement.ViewModel.Student_Manage_ViewModel;
using StudentManagement.ViewModel.Teacher_Manage_ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel.Class_Manage__ViewModel
{
    public class AddNewClass_WD_ViewModel : BaseViewModel
    {
        private ObservableCollection<STUDENT> _STUDENTLISTDTG;
        public ObservableCollection<STUDENT> STUDENTLISTDTG { get => _STUDENTLISTDTG; set { _STUDENTLISTDTG = value; OnPropertyChanged(); } }

        private ObservableCollection<NAM_HOC> _SCHOOLYEARLIST;
        public ObservableCollection<NAM_HOC> SCHOOLYEARLIST { get => _SCHOOLYEARLIST; set { _SCHOOLYEARLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _SchoolYearListCbb;
        public ObservableCollection<string> SchoolYearListCbb { get => _SchoolYearListCbb; set { _SchoolYearListCbb = value; OnPropertyChanged(); } }

        private ObservableCollection<KHOI_LOP> _GRADELIST;
        public ObservableCollection<KHOI_LOP> GRADELIST { get => _GRADELIST; set { _GRADELIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _GradeListCbb;
        public ObservableCollection<string> GradeListCbb { get => _GradeListCbb; set { _GradeListCbb = value; OnPropertyChanged(); } }

        

        private bool _isSelectedStudent;
        public bool isSelectedStudent { get => _isSelectedStudent; set { _isSelectedStudent = value; OnPropertyChanged(); } }


        private string _ClassName;
        public string ClassName { get => _ClassName; set { _ClassName = value; OnPropertyChanged(); } }

        private int _StudentCount;
        public int StudentCount { get => _StudentCount; set { _StudentCount = value; OnPropertyChanged(); } }

        private string _Grade;
        public string Grade { get => _Grade; set { _Grade = value; OnPropertyChanged(); } }

        private int _MaxQuantityStudent;
        public int MaxQuantityStudent { get => _MaxQuantityStudent; set { _MaxQuantityStudent = value; OnPropertyChanged(); } }

        private string _SchoolYear;
        public string SchoolYear { get => _SchoolYear; set { _SchoolYear = value; OnPropertyChanged(); } }

        private TEACHER _SelectedTeacher;
        public TEACHER SelectedTeacher { get => _SelectedTeacher; set { _SelectedTeacher = value; OnPropertyChanged(); } }

        private STUDENT _SelectedStudent;
        public STUDENT SelectedStudent { get => _SelectedStudent; set { _SelectedStudent = value; OnPropertyChanged(); } }

        private string _HomeroomTeacherName;
        public string HomeroomTeacherName { get => _HomeroomTeacherName; set { _HomeroomTeacherName = value; OnPropertyChanged(); } }

        private string _StudentName;
        public string StudentName { get => _StudentName; set { _StudentName = value; OnPropertyChanged(); } }

        private CLASS _selectedClass;
        public CLASS selectedClass { get => _selectedClass; set { _selectedClass = value; OnPropertyChanged(); } }


        private string _StudentBirthday;
        public string StudentBirthday { get => _StudentBirthday; set { _StudentBirthday = value; OnPropertyChanged(); } }


        public ICommand AddStudentToListCommand { get; set; }
        public ICommand Open_StudentList_WD_Command { get; set; }
        public ICommand ResetTextBoxCommand { get; set; }
        public ICommand CreateClassCommand { get; set; }
        public ICommand AddNewClassCommand { get; set; }
        public ICommand Open_TeacherList_WD_Command { get; set; }
        public ICommand QuitCommand { get; set; }

        #region Declare command EditClass_WD
        public ICommand ConfirmEditClassCommand { get; set; }
        public ICommand DeleteStudentFromListCommand { get; set; }

        #endregion
        public AddNewClass_WD_ViewModel()
        {
            LoadCombobox();
            STUDENTLISTDTG = new ObservableCollection<STUDENT>();
            StudentCount = 0;
            MaxQuantityStudent = 30;

            DeleteStudentFromListCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa học sinh khỏi lớp này?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    StudentName = "";
                    StudentBirthday = "";
                    isSelectedStudent = false;
                    STUDENTLISTDTG.Remove(SelectedStudent);
                    StudentCount -= 1;
                }
                else
                {
                    return;
                }
            });

            AddStudentToListCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                StudentName = "";
                StudentBirthday = "";
                isSelectedStudent = false;
                STUDENTLISTDTG.Add(SelectedStudent);
                StudentCount += 1;  
            });

            ConfirmEditClassCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ObservableCollection<HOC_SINH> studentList = new ObservableCollection<HOC_SINH>();

                foreach (var item in STUDENTLISTDTG)
                {
                    studentList.Add(item.hocsinh);
                }

                CLASS new_Class = new CLASS();
                if(string.IsNullOrEmpty(HomeroomTeacherName))
                {
                    SelectedTeacher.giaovien = null;
                    SelectedTeacher = new TEACHER();
                }    
                new_Class.EditClass(selectedClass.lop.MA_LOP, ClassName, Grade, MaxQuantityStudent, SchoolYear, SelectedTeacher.giaovien, studentList);
                p.Close();

                Class_UC class_UC = new Class_UC();
                var class_UC_DT = class_UC.DataContext as Class_UC_ViewModel;
                class_UC_DT.LoadClassList();
            });
            AddNewClassCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                ObservableCollection<HOC_SINH> studentList = new ObservableCollection<HOC_SINH>();

                foreach(var item in STUDENTLISTDTG)
                {
                    studentList.Add(item.hocsinh);
                }    

                CLASS new_Class = new CLASS();
                new_Class.AddNewClass(ClassName,Grade,MaxQuantityStudent,SchoolYear,SelectedTeacher.giaovien, studentList);
                p.Close();

                Class_UC class_UC = new Class_UC();
                var class_UC_DT = class_UC.DataContext as Class_UC_ViewModel;
                class_UC_DT.LoadClassList();
            });
            Open_TeacherList_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TeacherList_WD teacherList_WD = new TeacherList_WD();
                var teacherList_WD_DT = teacherList_WD.DataContext as Teacher_UC_ViewModel;
                teacherList_WD_DT.LoadTeacherListNotHomeroomTeacher();
                teacherList_WD.ShowDialog();
                teacherList_WD.Close();
                if (teacherList_WD_DT.SelectedTeacher == null)
                {
                    return;
                }
                else
                {
                    SelectedTeacher = teacherList_WD_DT.SelectedTeacher;
                    HomeroomTeacherName = SelectedTeacher.giaovien.HO_TEN;
                }
            });

            Open_StudentList_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                if (StudentCount >= MaxQuantityStudent)
                {
                    isSelectedStudent = false;
                    MessageBox.Show("Số lượng học sinh đã vượt quá sỉ số tối đa!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                StudentList_WD studentList_WD = new StudentList_WD();
                var studentList_WD_DT = studentList_WD.DataContext as Student_UC_ViewModel;
                studentList_WD_DT.LoadStudentListNotHaveClass(STUDENTLISTDTG);
                studentList_WD.ShowDialog();
                studentList_WD.Close();
                if (studentList_WD_DT.SelectedStudent == null)
                {
                    return;
                }
                else
                {
                    SelectedStudent = studentList_WD_DT.SelectedStudent;
                    StudentName = SelectedStudent.hocsinh.HO_TEN;
                    StudentBirthday = SelectedStudent.hocsinh.NGAY_SINH;
                    isSelectedStudent = true;
                }
            });

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
        }
        public void LoadCombobox()
        {
            GRADELIST = new ObservableCollection<KHOI_LOP>(DataProvider.Ins.DB.KHOI_LOP);
            GradeListCbb = new ObservableCollection<string>();
            foreach (var item in GRADELIST)
            {
                GradeListCbb.Add(item.TEN_KHOI_LOP);
            }
            SCHOOLYEARLIST = new ObservableCollection<NAM_HOC>(DataProvider.Ins.DB.NAM_HOC);
            SchoolYearListCbb = new ObservableCollection<string>();

            foreach (var item in SCHOOLYEARLIST)
            {
                SchoolYearListCbb.Add(item.TEN_NAM_HOC);
            }
        }

        public void LoadSelectedClass()
        {
            SelectedTeacher = new TEACHER();
            ClassName = selectedClass.lop.TEN_LOP;
            MaxQuantityStudent = Convert.ToInt32(selectedClass.lop.SI_SO_TOI_DA);
            SchoolYear = selectedClass.lop.NAM_HOC.TEN_NAM_HOC;
            Grade = selectedClass.lop.KHOI_LOP.TEN_KHOI_LOP;
            if (selectedClass.lop.GIAO_VIEN == null)
            {
                HomeroomTeacherName = "";
            }
            else
            {
                SelectedTeacher.giaovien = DataProvider.Ins.DB.GIAO_VIEN.Where(x=>x.MA_GIAO_VIEN == selectedClass.lop.MA_GVCN).SingleOrDefault();
                HomeroomTeacherName = SelectedTeacher.giaovien.HO_TEN;
            }    
            StudentCount = Convert.ToInt32(selectedClass.lop.SI_SO);

            ObservableCollection<CT_LOP_HOC_SINH> class_Student_Detail  = new ObservableCollection<CT_LOP_HOC_SINH>(DataProvider.Ins.DB.CT_LOP_HOC_SINH.Where(x => x.MA_LOP == selectedClass.lop.MA_LOP));
            STUDENTLISTDTG = new ObservableCollection<STUDENT>();
            foreach(var item in class_Student_Detail)
            {
                STUDENT tempStudent = new STUDENT();
                tempStudent.hocsinh = item.HOC_SINH;

                STUDENTLISTDTG.Add(tempStudent);
            }    
        }

        public void ResetTextbox()
        {
            ClassName = "";
            MaxQuantityStudent = 40;
            SchoolYear = "";
            Grade = "";
            SelectedTeacher = new TEACHER();
            HomeroomTeacherName = "";
            StudentName = "";
            StudentBirthday = "";
            STUDENTLISTDTG = new ObservableCollection<STUDENT>();
        }
    }
}
