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
using System.Windows.Input;

namespace StudentManagement.ViewModel.Student_Manage_ViewModel
{
    public class Student_UC_ViewModel : BaseViewModel
    {
        #region Binding STUDENT_UC
        
        private STUDENT _SelectedStudent;
        public STUDENT SelectedStudent { get => _SelectedStudent; set { _SelectedStudent = value; OnPropertyChanged(); } }
        
        private ObservableCollection<HOC_SINH> _STUDENTLIST;
        public ObservableCollection<HOC_SINH> STUDENTLIST { get => _STUDENTLIST; set { _STUDENTLIST = value; OnPropertyChanged(); } }
        
        private ObservableCollection<STUDENT> _STUDENTLISTDTG;
        public ObservableCollection<STUDENT> STUDENTLISTDTG { get => _STUDENTLISTDTG; set { _STUDENTLISTDTG = value; OnPropertyChanged(); } }
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
            LoadStudentList();

            #region Handling command Button STUDENT_UC
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
            STUDENTLIST = new ObservableCollection<HOC_SINH>(DataProvider.Ins.DB.HOC_SINH.Where(x=>x.DA_CO_LOP_HOC == false));
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
