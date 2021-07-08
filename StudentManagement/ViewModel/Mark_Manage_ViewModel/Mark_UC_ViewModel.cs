using StudentManagement.Model;
using StudentManagement.Model.MARK;
using StudentManagement.View.Mark_Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace StudentManagement.ViewModel.Mark_Manage_ViewModel
{
    public class Mark_UC_ViewModel : BaseViewModel
    {
        #region

        private ObservableCollection<STUDENT_MARK> _STUDENTMARKLISTDTG;
        public ObservableCollection<STUDENT_MARK> STUDENTMARKLISTDTG { get => _STUDENTMARKLISTDTG; set { _STUDENTMARKLISTDTG = value; OnPropertyChanged(); } }

        private ObservableCollection<DIEM> _MARKLIST;
        public ObservableCollection<DIEM> MARKLIST { get => _MARKLIST; set { _MARKLIST = value; OnPropertyChanged(); } }

        private STUDENT_MARK _SelectedStudentMark;
        public STUDENT_MARK SelectedStudentMark { get => _SelectedStudentMark; set { _SelectedStudentMark = value; OnPropertyChanged(); } }

        private ObservableCollection<NAM_HOC> _SCHOOLYEARLIST;
        public ObservableCollection<NAM_HOC> SCHOOLYEARLIST { get => _SCHOOLYEARLIST; set { _SCHOOLYEARLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _SchoolYearListCbb;
        public ObservableCollection<string> SchoolYearListCbb { get => _SchoolYearListCbb; set { _SchoolYearListCbb = value; OnPropertyChanged(); } }

        private string _SelectedSchoolYear;
        public string SelectedSchoolYear { get => _SelectedSchoolYear; set { _SelectedSchoolYear = value; OnPropertyChanged(); } }


        private string _SelectedSemester;
        public string SelectedSemester { get => _SelectedSemester; set { _SelectedSemester = value; OnPropertyChanged(); } }

        private string _SelectedGradeClass;
        public string SelectedGradeClass { get => _SelectedGradeClass; set { _SelectedGradeClass = value; OnPropertyChanged(); } }

        private ObservableCollection<LOP> _CLASSLIST;
        public ObservableCollection<LOP> CLASSLIST { get => _CLASSLIST; set { _CLASSLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ClassListCbb;
        public ObservableCollection<string> ClassListCbb { get => _ClassListCbb; set { _ClassListCbb = value; OnPropertyChanged(); } }

        private string _SelectedClassName;
        public string SelectedClassName { get => _SelectedClassName; set { _SelectedClassName = value; OnPropertyChanged(); } }

        private string _SelectedSubjectName;
        public string SelectedSubjectName { get => _SelectedSubjectName; set { _SelectedSubjectName = value; OnPropertyChanged(); } }



        #endregion
        #region Declare Command
        public ICommand FindCommand { get; set; }
        public ICommand DefaultCommand { get; set; }
        public ICommand Open_EditStudentMark_WD_Command { get; set; }
        #endregion
        public Mark_UC_ViewModel()
        {
            LoadCombobox();
            FindCommand = new RelayCommand<object>((p) =>
            {

                return true;
            }, (p) =>
            {
                LoadDTG();
            });
            DefaultCommand = new RelayCommand<object>((p) =>
            {

                return true;
            }, (p) =>
            {
                Reset();
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
                LoadDTG();
            });
        }

        public void LoadCombobox()
        {
            SCHOOLYEARLIST = new ObservableCollection<NAM_HOC>(DataProvider.Ins.DB.NAM_HOC);
            SchoolYearListCbb = new ObservableCollection<string>();


            foreach(var item in SCHOOLYEARLIST)
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

        public void LoadDTG()
        {
            STUDENTMARKLISTDTG = new ObservableCollection<STUDENT_MARK>();
            MARKLIST = new ObservableCollection<DIEM>();

            ObservableCollection<QUA_TRINH_HOC_MON_HOC> tempList = new ObservableCollection<QUA_TRINH_HOC_MON_HOC>(DataProvider.Ins.DB.QUA_TRINH_HOC_MON_HOC);

            foreach(var item in tempList)
            {
                STUDENT_MARK tempStudentMark = new STUDENT_MARK();
                tempStudentMark.qt_hoc_mon_hoc = item;
                tempStudentMark.LoadScore();
                STUDENTMARKLISTDTG.Add(tempStudentMark);
            }

            NAM_HOC selectedSchoolYear = new NAM_HOC();
            HOC_KY selectedSemester = new HOC_KY();
            if(!string.IsNullOrEmpty(SelectedSchoolYear))
            {
                selectedSchoolYear = DataProvider.Ins.DB.NAM_HOC.Where(x => x.TEN_NAM_HOC == SelectedSchoolYear).SingleOrDefault();
            }    
            if(!string.IsNullOrEmpty(SelectedSemester))
            {
                selectedSemester = DataProvider.Ins.DB.HOC_KY.Where(x => x.TEN_HOC_KY == SelectedSemester && x.MA_NAM_HOC == selectedSchoolYear.MA_NAM_HOC).SingleOrDefault();
            }    
            CollectionViewSource.GetDefaultView(STUDENTMARKLISTDTG).Filter = (studentMarkFind) =>
            {
                return (studentMarkFind as STUDENT_MARK).qt_hoc_mon_hoc.MON_HOC.TEN_MON_HOC.IndexOf(SelectedSubjectName, StringComparison.OrdinalIgnoreCase) >= 0 &&
                           (studentMarkFind as STUDENT_MARK).qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.LOP.TEN_LOP.IndexOf(SelectedClassName, StringComparison.OrdinalIgnoreCase) >= 0 &&
                           (studentMarkFind as STUDENT_MARK).qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.HOC_KY.MA_HOC_KY.ToString().IndexOf(selectedSemester.MA_HOC_KY.ToString(), StringComparison.OrdinalIgnoreCase) >= 0 &&
                           (studentMarkFind as STUDENT_MARK).qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.HOC_KY.NAM_HOC.TEN_NAM_HOC.IndexOf(SelectedSchoolYear, StringComparison.OrdinalIgnoreCase) >= 0;
            };
        }    
        public void Reset()
        {
            SelectedSchoolYear = "";
            SelectedSemester = "";
            SelectedGradeClass = "";
            SelectedClassName = "";
            SelectedSubjectName = "";
            STUDENTMARKLISTDTG = new ObservableCollection<STUDENT_MARK>();
        }    
    }
}
