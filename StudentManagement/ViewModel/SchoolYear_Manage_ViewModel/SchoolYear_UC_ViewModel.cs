using StudentManagement.Model;
using StudentManagement.View.SchoolYear_Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagement.ViewModel.SchoolYear_Manage_ViewModel
{
    public class SchoolYear_UC_ViewModel : BaseViewModel
    {
        #region Command
        public ICommand Open_AddNewSchoolYear_WD_Command { get; set; }
        public ICommand EditSchoolYear { get; set; }
        #endregion

        
        private NAM_HOC _selectedSchoolYear;
        public NAM_HOC selectedSchoolYear { get => _selectedSchoolYear; set { _selectedSchoolYear = value; OnPropertyChanged(); } }
        private ObservableCollection<NAM_HOC> _SCHOOLYEARLIST;
        public ObservableCollection<NAM_HOC> SCHOOLYEARLIST { get => _SCHOOLYEARLIST; set { _SCHOOLYEARLIST = value; OnPropertyChanged(); } }

        private string _Semester_1_StartDay;
        public string Semester_1_StartDay { get => _Semester_1_StartDay; set { _Semester_1_StartDay = value; OnPropertyChanged(); } }
        private string _Semester_2_StartDay;
        public string Semester_2_StartDay { get => _Semester_2_StartDay; set { _Semester_2_StartDay = value; OnPropertyChanged(); } }
        private string _Semester_1_EndDay;
        public string Semester_1_EndDay { get => _Semester_1_EndDay; set { _Semester_1_EndDay = value; OnPropertyChanged(); } }
        private string _Semester_2_EndDay;
        public string Semester_2_EndDay { get => _Semester_1_EndDay; set { _Semester_1_EndDay = value; OnPropertyChanged(); } }

        public SchoolYear_UC_ViewModel()
        {
            LoadSchoolYearList();
            EditSchoolYear = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                HOC_KY temp1 = new HOC_KY();
                temp1 = DataProvider.Ins.DB.HOC_KY.Where(x => x.MA_NAM_HOC == selectedSchoolYear.MA_NAM_HOC && x.TEN_HOC_KY == "Học kỳ 1").SingleOrDefault();

                HOC_KY temp2 = new HOC_KY();
                temp2 = DataProvider.Ins.DB.HOC_KY.Where(x => x.MA_NAM_HOC == selectedSchoolYear.MA_NAM_HOC && x.TEN_HOC_KY == "Học kỳ 2").SingleOrDefault();


                Semester_1_StartDay = temp1.NGAY_BAT_DAU;
                Semester_1_EndDay = temp1.NGAY_KET_THUC;
                Semester_2_StartDay = temp2.NGAY_BAT_DAU;
                Semester_2_EndDay = temp2.NGAY_KET_THUC;
            });
            Open_AddNewSchoolYear_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewSchoolYear_WD addNewSchoolYear_WD = new AddNewSchoolYear_WD();
                var addNewSchoolYear_WD_VM = addNewSchoolYear_WD.DataContext as AddNewSchoolYear_WD_ViewModel;
                addNewSchoolYear_WD_VM.ResetTextbox();
                addNewSchoolYear_WD.ShowDialog();
                addNewSchoolYear_WD.Close();
                LoadSchoolYearList();
            });
        }

        public void LoadSchoolYearList()
        {
            SCHOOLYEARLIST = new ObservableCollection<NAM_HOC>(DataProvider.Ins.DB.NAM_HOC);
        }
    }
}
