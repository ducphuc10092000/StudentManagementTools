using StudentManagement.Model;
using StudentManagement.Model.MARK;
using StudentManagement.View.Mark_Manage;
using StudentManagement.View.Summary_Manage;
using StudentManagement.ViewModel.Mark_Manage_ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel.Summary_Manage_ViewModel
{
    public class Summary_UC_ViewModel : BaseViewModel
    {
        public ICommand FindCommand { get; set; }

        public ICommand DefaultCommand { get; set; }

        public ICommand ExportExcelFileCommand { get; set; }

        public ICommand Open_StudentDetailMark_WD_Command { get; set; }

        public ICommand Open_EditStudentMark_WD_Command { get; set; }
        public ICommand QuitCommand { get; set; }
        public ICommand ConfirmEditStudentMarkSummaryCommand { get; set; }

        

        private string _SummaryResult;
        public string SummaryResult { get => _SummaryResult; set { _SummaryResult = value; OnPropertyChanged(); } }
        private string _SelectedConduct;
        public string SelectedConduct { get => _SelectedConduct; set { _SelectedConduct = value; OnPropertyChanged(); } }


        private string _SelectedSchoolYear;
        public string SelectedSchoolYear { get => _SelectedSchoolYear; set { _SelectedSchoolYear = value; OnPropertyChanged(); } }
        
        private string _SelectedClassName;
        public string SelectedClassName { get => _SelectedClassName; set { _SelectedClassName = value; OnPropertyChanged(); } }

        private string _SelectedSemester;
        public string SelectedSemester { get => _SelectedSemester; set { _SelectedSemester = value; OnPropertyChanged(); } }


        private ObservableCollection<string> _SchoolYearListCbb;
        public ObservableCollection<string> SchoolYearListCbb { get => _SchoolYearListCbb; set { _SchoolYearListCbb = value; OnPropertyChanged(); } }

        private ObservableCollection<NAM_HOC> _SCHOOLYEARLIST;
        public ObservableCollection<NAM_HOC> SCHOOLYEARLIST { get => _SCHOOLYEARLIST; set { _SCHOOLYEARLIST = value; OnPropertyChanged(); } }


        private ObservableCollection<string> _ClassListCbb;
        public ObservableCollection<string> ClassListCbb { get => _ClassListCbb; set { _ClassListCbb = value; OnPropertyChanged(); } }

        private ObservableCollection<LOP> _CLASSLIST;
        public ObservableCollection<LOP> CLASSLIST { get => _CLASSLIST; set { _CLASSLIST = value; OnPropertyChanged(); } }


        private ObservableCollection<DIEM> _MARKLIST;
        public ObservableCollection<DIEM> MARKLIST { get => _MARKLIST; set { _MARKLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<STUDENT_MARK> _STUDENTMARKLISTDTG;
        public ObservableCollection<STUDENT_MARK> STUDENTMARKLISTDTG { get => _STUDENTMARKLISTDTG; set { _STUDENTMARKLISTDTG = value; OnPropertyChanged(); } }
        private STUDENT_MARK _SelectedStudentMark;
        public STUDENT_MARK SelectedStudentMark { get => _SelectedStudentMark; set { _SelectedStudentMark = value; OnPropertyChanged(); } }


        private ObservableCollection<QUA_TRINH_HOC_HOC_KY> _SEMESTER_PROCESS_LIST;
        public ObservableCollection<QUA_TRINH_HOC_HOC_KY> SEMESTER_PROCESS_LIST { get => _SEMESTER_PROCESS_LIST; set { _SEMESTER_PROCESS_LIST = value; OnPropertyChanged(); } }

        private ObservableCollection<QUA_TRINH_HOC_HOC_KY> _SEMESTER_PROCESS_LIST_DTG;
        public ObservableCollection<QUA_TRINH_HOC_HOC_KY> SEMESTER_PROCESS_LIST_DTG { get => _SEMESTER_PROCESS_LIST_DTG; set { _SEMESTER_PROCESS_LIST_DTG = value; OnPropertyChanged(); } }


        private QUA_TRINH_HOC_HOC_KY _SelectedStudent_Semester_Process;
        public QUA_TRINH_HOC_HOC_KY SelectedStudent_Semester_Process { get => _SelectedStudent_Semester_Process; set { _SelectedStudent_Semester_Process = value; OnPropertyChanged(); } }



        public Summary_UC_ViewModel()
        {
            LoadCombobox();
            ConfirmEditStudentMarkSummaryCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                //MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn muốn chỉnh sửa?", "Thông báo", MessageBoxButton.YesNo);
                //if (result == MessageBoxResult.Yes)
                //{
                //    SelectedStudent_Semester_Process.HANH_KIEM = DataProvider.Ins.DB.HANH_KIEM.Where(x => x.TEN_HANH_KIEM == SelectedConduct).SingleOrDefault();


                //    //Xét đạt hay không đạt... - xếp loại học sinh
                //    ObservableCollection<QUA_TRINH_HOC_MON_HOC> tempQTHMH = new ObservableCollection<QUA_TRINH_HOC_MON_HOC>(DataProvider.Ins.DB.QUA_TRINH_HOC_MON_HOC.Where(x => x.MA_QTHK == SelectedStudent_Semester_Process.MA_QTHK));
                //    foreach (var item in tempQTHMH)
                //    {

                       
                //        if (0 <= item.DIEM_TB_MON_HOC && item.DIEM_TB_MON_HOC <= 2)
                //        {
                //            SelectedStudent_Semester_Process.XEP_LOAI = DataProvider.Ins.DB.XEP_LOAI.Where(x => x.TEN_XEP_LOAI == "Kém").SingleOrDefault();
                //        }
                //        else if (2 < item.DIEM_TB_MON_HOC && item.DIEM_TB_MON_HOC < 3.5)
                //        {
                //            SelectedStudent_Semester_Process.XEP_LOAI = DataProvider.Ins.DB.XEP_LOAI.Where(x => x.TEN_XEP_LOAI == "Yếu").SingleOrDefault();
                //        }
                //        else if (3.5 <= item.DIEM_TB_MON_HOC && item.DIEM_TB_MON_HOC < 5)
                //        {
                //            SelectedStudent_Semester_Process.XEP_LOAI = DataProvider.Ins.DB.XEP_LOAI.Where(x => x.TEN_XEP_LOAI == "Trung bình").SingleOrDefault();
                //        }
                        
                //        //Xếp loại tb
                //        //Điểm tb môn học
                //        else if (5 <= item.DIEM_TB_MON_HOC && item.DIEM_TB_MON_HOC < 6.5)
                //        {
                //            SelectedStudent_Semester_Process.XEP_LOAI = DataProvider.Ins.DB.XEP_LOAI.Where(x => x.TEN_XEP_LOAI == "Khá").SingleOrDefault();
                //        }


                //        else if (6.5 <= item.DIEM_TB_MON_HOC && item.DIEM_TB_MON_HOC < 8)
                //        {

                //        }    
                //        //Xếp loại giỏi
                //        //Điểm tb toán || văn || ngoại ngữ > = 8
                //        // điểm tb toàn kỳ >= 8
                //        // không có môn nào dưới 6.5
                //        else if (8 <= item.DIEM_TB_MON_HOC && item.DIEM_TB_MON_HOC <= 10)
                //        {
                //            if (SelectedStudent_Semester_Process.DIEM_TB >= 8)
                //            {
                //                if ((item.MON_HOC.TEN_MON_HOC == "Toán" || item.MON_HOC.TEN_MON_HOC == "Văn" || item.MON_HOC.TEN_MON_HOC == "Ngoại ngữ") && item.DIEM_TB_MON_HOC >= 8)
                //                {
                //                    SelectedStudent_Semester_Process.XEP_LOAI = DataProvider.Ins.DB.XEP_LOAI.Where(x => x.TEN_XEP_LOAI == "Giỏi").SingleOrDefault();
                //                }
                //            }
                //        }

                //    }
                //    p.Close();
                //}
                //else
                //{
                //    return;
                //}
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
            FindCommand = new RelayCommand<object>((p) =>
            {

                return true;
            }, (p) =>
            {
                LoadSemesterProcessList();
            });
            Open_StudentDetailMark_WD_Command = new RelayCommand<object>((p) =>
            {

                return true;
            }, (p) =>
            {
                LoadStudentMark();

                EditSummary_WD editSummary_WD = new EditSummary_WD();
                
                editSummary_WD.ShowDialog();
                editSummary_WD.Close();

            });
            Open_EditStudentMark_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditMark_WD editMark_WD = new EditMark_WD();
                var editMark_WD_DT = editMark_WD.DataContext as EditMark_WD_ViewModel;
                editMark_WD_DT.SelectedStudentMark = SelectedStudentMark;
                editMark_WD_DT.LoadSelectedStudentMark();
                editMark_WD.ShowDialog();
                editMark_WD.Close();
                LoadStudentMark();
            });
        }

        public void LoadCombobox()
        {
            SCHOOLYEARLIST = new ObservableCollection<NAM_HOC>(DataProvider.Ins.DB.NAM_HOC);
            SchoolYearListCbb = new ObservableCollection<string>();


            foreach (var item in SCHOOLYEARLIST)
            {
                SchoolYearListCbb.Add(item.TEN_NAM_HOC);
            }

            CLASSLIST = new ObservableCollection<LOP>(DataProvider.Ins.DB.LOPs);
            ClassListCbb = new ObservableCollection<string>();
            foreach (var item in CLASSLIST)
            {
                ClassListCbb.Add(item.TEN_LOP);
            }
        }

        public void LoadSemesterProcessList()
        {
            NAM_HOC selectedSchoolYear = new NAM_HOC();
            HOC_KY selectedSemester = new HOC_KY();
            LOP selectedClass = new LOP();
            if (!string.IsNullOrEmpty(SelectedSchoolYear))
            {
                selectedSchoolYear = DataProvider.Ins.DB.NAM_HOC.Where(x => x.TEN_NAM_HOC == SelectedSchoolYear).SingleOrDefault();
            }
            else
            {
                MessageBox.Show("Chưa chọn năm học!");
                return;
            }
            if (!string.IsNullOrEmpty(SelectedSemester))
            {
                selectedSemester = DataProvider.Ins.DB.HOC_KY.Where(x => x.TEN_HOC_KY == SelectedSemester && x.MA_NAM_HOC == selectedSchoolYear.MA_NAM_HOC).SingleOrDefault();
            }
            else
            {
                MessageBox.Show("Chưa chọn học kỳ!");
                return;
            }
            if (!string.IsNullOrEmpty(SelectedClassName))
            {
                selectedClass = DataProvider.Ins.DB.LOPs.Where(x => x.TEN_LOP == SelectedClassName && x.MA_NAM_HOC == selectedSchoolYear.MA_NAM_HOC).SingleOrDefault();
            }
            else
            {
                MessageBox.Show("Chưa chọn lớp học!");
                return;
            }

            SEMESTER_PROCESS_LIST = new ObservableCollection<QUA_TRINH_HOC_HOC_KY>(DataProvider.Ins.DB.QUA_TRINH_HOC_HOC_KY.Where(x=>x.MA_HOC_KY == selectedSemester.MA_HOC_KY && x.MA_LOP == selectedClass.MA_LOP));
            SEMESTER_PROCESS_LIST_DTG = new ObservableCollection<QUA_TRINH_HOC_HOC_KY>();
            foreach (var item in SEMESTER_PROCESS_LIST)
            {
                SEMESTER_PROCESS_LIST_DTG.Add(item);
            }    
        }

        public void LoadStudentMark()
        {
            STUDENTMARKLISTDTG = new ObservableCollection<STUDENT_MARK>();
            MARKLIST = new ObservableCollection<DIEM>();
            double tempDIEMTB = new double();
            tempDIEMTB = 0;

            SelectedStudent_Semester_Process.DIEM_TB = 0;

            ObservableCollection<QUA_TRINH_HOC_MON_HOC> tempQTHMH = new ObservableCollection<QUA_TRINH_HOC_MON_HOC>(DataProvider.Ins.DB.QUA_TRINH_HOC_MON_HOC.Where(x=>x.MA_QTHK == SelectedStudent_Semester_Process.MA_QTHK));
            foreach (var item in tempQTHMH)
            {
                STUDENT_MARK tempStudentMark = new STUDENT_MARK();
                tempStudentMark.qt_hoc_mon_hoc = item;
                tempStudentMark.LoadScore();
                STUDENTMARKLISTDTG.Add(tempStudentMark);
                tempDIEMTB += Convert.ToDouble(tempStudentMark.qt_hoc_mon_hoc.DIEM_TB_MON_HOC);
            }
            SelectedStudent_Semester_Process.DIEM_TB = tempDIEMTB / tempQTHMH.Count();
            DataProvider.Ins.DB.SaveChanges();

        }
    }
}
