using StudentManagement.Model;
using StudentManagement.Model.STUDENT;
using StudentManagement.View.Student_Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace StudentManagement.ViewModel.Student_Manage_ViewModel
{
    public class Student_UC_ViewModel : BaseViewModel
    {
        #region Binding STUDENT_UC
        
        private STUDENT _SelectedStudent;
        public STUDENT SelectedStudent { get => _SelectedStudent; set { _SelectedStudent = value; OnPropertyChanged(); } }

        private string _StudentNameFind;
        public string StudentNameFind { get => _StudentNameFind; set { _StudentNameFind = value; OnPropertyChanged(); } }

        private string _SelectedClassName;
        public string SelectedClassName { get => _SelectedClassName; set { _SelectedClassName = value; OnPropertyChanged(); } }

        private ObservableCollection<HOC_SINH> _STUDENTLIST;
        public ObservableCollection<HOC_SINH> STUDENTLIST { get => _STUDENTLIST; set { _STUDENTLIST = value; OnPropertyChanged(); } }
        
        private ObservableCollection<STUDENT> _STUDENTLISTDTG;
        public ObservableCollection<STUDENT> STUDENTLISTDTG { get => _STUDENTLISTDTG; set { _STUDENTLISTDTG = value; OnPropertyChanged(); } }

        private ObservableCollection<LOP> _CLASSLIST;
        public ObservableCollection<LOP> CLASSLIST { get => _CLASSLIST; set { _CLASSLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ClassListCbb;
        public ObservableCollection<string> ClassListCbb { get => _ClassListCbb; set { _ClassListCbb = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand StudentFindCommand { get; set; }
        public ICommand StudentDefaultFilterCommand { get; set; }
        public ICommand Open_AddNewStudent_WD_Command { get; set; }
        public ICommand Open_EditStudent_WD_Command { get; set; }
        public ICommand DoubleClickSelectStudentCommand { get; set; }
        public ICommand QuitCommand { get; set; }
        #endregion
        public Student_UC_ViewModel()
        {
            LoadCombobox();
            LoadStudentList();

            #region Handling command Button STUDENT_UC
            StudentFindCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                Filter();
            });
            StudentDefaultFilterCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                CollectionViewSource.GetDefaultView(STUDENTLISTDTG).Filter = (all) => { return true; };
            });
            Open_AddNewStudent_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewStudent_WD addNewStudent_WD = new AddNewStudent_WD();
                var addNewStudent_WD_VM = addNewStudent_WD.DataContext as AddNewStudent_WD_ViewModel;
                addNewStudent_WD_VM.ResetTextbox();
                addNewStudent_WD.ShowDialog();
                addNewStudent_WD.Close();
            });

            Open_EditStudent_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditStudent_WD editStudent_WD = new EditStudent_WD();
                var editStudent_WD_DT = editStudent_WD.DataContext as AddNewStudent_WD_ViewModel;
                editStudent_WD_DT.LoadSelectedStudent(Convert.ToInt32(p));
                editStudent_WD.ShowDialog();
                editStudent_WD.Close();
            });
            #endregion

            #region Handling StudentList_WD
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

            DoubleClickSelectStudentCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                if (SelectedStudent == null)
                {
                    return;
                }
                else
                {
                    p.Close();
                }
            });
            #endregion

        }

        public void Filter()
        {
            if(string.IsNullOrEmpty(StudentNameFind))
            {
                if(string.IsNullOrEmpty(SelectedClassName))
                {
                    MessageBox.Show("Vui lòng nhập thông tin rồi bấm tìm kiếm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }    
                else
                {
                    CollectionViewSource.GetDefaultView(STUDENTLISTDTG).Filter = (studentFind) =>
                    {
                        return (studentFind as STUDENT).lop_hien_tai.IndexOf(SelectedClassName, StringComparison.OrdinalIgnoreCase) >= 0;
                    };
                }    
            }    
            else
            {
                if (string.IsNullOrEmpty(SelectedClassName))
                {
                    CollectionViewSource.GetDefaultView(STUDENTLISTDTG).Filter = (studentFind) =>
                    {
                        return (studentFind as STUDENT).hocsinh.HO_TEN.IndexOf(StudentNameFind, StringComparison.OrdinalIgnoreCase) >= 0;
                    };
                }
                else
                {
                    CollectionViewSource.GetDefaultView(STUDENTLISTDTG).Filter = (studentFind) =>
                    {
                        return (studentFind as STUDENT).lop_hien_tai.IndexOf(SelectedClassName, StringComparison.OrdinalIgnoreCase) >= 0 &&
                                (studentFind as STUDENT).hocsinh.HO_TEN.IndexOf(StudentNameFind, StringComparison.OrdinalIgnoreCase) >= 0;
                    };
                }
            }    
            //CollectionViewSource.GetDefaultView(STUDENTLISTDTG).Filter = (studentMarkFind) =>
            //{
            //    return (studentMarkFind as STUDENT_MARK).qt_hoc_mon_hoc.MON_HOC.TEN_MON_HOC.IndexOf(SelectedSubjectName, StringComparison.OrdinalIgnoreCase) >= 0 &&
            //               (studentMarkFind as STUDENT_MARK).qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.LOP.TEN_LOP.IndexOf(SelectedClassName, StringComparison.OrdinalIgnoreCase) >= 0 &&
            //               (studentMarkFind as STUDENT_MARK).qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.HOC_KY.MA_HOC_KY.ToString().IndexOf(selectedSemester.MA_HOC_KY.ToString(), StringComparison.OrdinalIgnoreCase) >= 0 &&
            //               (studentMarkFind as STUDENT_MARK).qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.HOC_KY.NAM_HOC.TEN_NAM_HOC.IndexOf(SelectedSchoolYear, StringComparison.OrdinalIgnoreCase) >= 0;
            //};
        }

        public void LoadCombobox()
        {
            ClassListCbb = new ObservableCollection<string>();
            CLASSLIST = new ObservableCollection<LOP>(DataProvider.Ins.DB.LOPs);

            var orderAs = from s in CLASSLIST
                          orderby s.TEN_LOP
                          select s;

            foreach(var item in orderAs)
            {
                ClassListCbb.Add(item.TEN_LOP);
            }
        }
        public void LoadStudentList()
        {
            STUDENTLIST = new ObservableCollection<HOC_SINH>(DataProvider.Ins.DB.HOC_SINH);
            STUDENTLISTDTG = new ObservableCollection<STUDENT>();

            foreach (var item in STUDENTLIST)
            {
                STUDENT temp_student = new STUDENT();

                temp_student.hocsinh = item;
                if(item.LOP != null)
                {
                    temp_student.lop_hien_tai = item.LOP.TEN_LOP;
                }    

                STUDENTLISTDTG.Add(temp_student);
            }
        }
        public void LoadStudentListNotHaveClass(ObservableCollection<STUDENT> studentListDTGInClass)
        {
            STUDENTLIST = new ObservableCollection<HOC_SINH>(DataProvider.Ins.DB.HOC_SINH.Where(x=>x.DA_CO_LOP_HOC == false || x.DA_CO_LOP_HOC == null || x.MA_LOP_DANG_HOC == null));
            STUDENTLISTDTG = new ObservableCollection<STUDENT>();
            foreach (var item in STUDENTLIST)
            {
                STUDENT temp_student = new STUDENT();
                temp_student.hocsinh = item;
                STUDENTLISTDTG.Add(temp_student);

                //Check hoc sinh da co trong List tai AddNewClass
                foreach(var item2 in studentListDTGInClass)
                {
                    if(item2.hocsinh == item)
                    {
                        STUDENTLISTDTG.Remove(temp_student);
                    }    
                }    
            }
            MessageBox.Show(STUDENTLISTDTG.Count().ToString());
        }
    }
}
