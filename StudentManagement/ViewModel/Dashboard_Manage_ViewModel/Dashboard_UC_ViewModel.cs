using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using StudentManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel.Dashboard_Manage_ViewModel
{
    public class Dashboard_UC_ViewModel : BaseViewModel
    {
        public  ICommand UpdateDataCommand { get; set; }

        private ObservableCollection<LOP> _CLASSLIST;
        public ObservableCollection<LOP> CLASSLIST { get => _CLASSLIST; set { _CLASSLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<HOC_SINH> _STUDENTLIST;
        public ObservableCollection<HOC_SINH> STUDENTLIST { get => _STUDENTLIST; set { _STUDENTLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<GIAO_VIEN> _TEACHERLIST;
        public ObservableCollection<GIAO_VIEN> TEACHERLIST { get => _TEACHERLIST; set { _TEACHERLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<HOC_KY> _SEMESTERLIST;
        public ObservableCollection<HOC_KY> SEMESTERLIST { get => _SEMESTERLIST; set { _SEMESTERLIST = value; OnPropertyChanged(); } }

        private HOC_KY _CurrentSemester;
        public HOC_KY CurrentSemester { get => _CurrentSemester; set { _CurrentSemester = value; OnPropertyChanged(); } }

        private SeriesCollection _GradeStudentCollection;
        public SeriesCollection GradeStudentCollection { get => _GradeStudentCollection; set { _GradeStudentCollection = value; OnPropertyChanged(); } }

        private SeriesCollection _GradeCollection;
        public SeriesCollection GradeCollection { get => _GradeCollection; set { _GradeCollection = value; OnPropertyChanged(); } }



        public Dashboard_UC_ViewModel()
        {
            Setup_Collection();
            UpdateDataCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                Setup_Collection();
            });
        }
        public void Setup_Collection()
        {
            SEMESTERLIST = new ObservableCollection<HOC_KY>(DataProvider.Ins.DB.HOC_KY);
            CurrentSemester = new HOC_KY();
            foreach (var semester in SEMESTERLIST)
            {
                if (DateTime.Parse(semester.NGAY_BAT_DAU, CultureInfo.CreateSpecificCulture("vi-VN")) <= DateTime.Today &&
                    DateTime.Parse(semester.NGAY_KET_THUC, CultureInfo.CreateSpecificCulture("vi-VN")) >= DateTime.Today)
                {
                    CurrentSemester = semester;
                }

            }

            STUDENTLIST = new ObservableCollection<HOC_SINH>(DataProvider.Ins.DB.HOC_SINH);
            TEACHERLIST = new ObservableCollection<GIAO_VIEN>(DataProvider.Ins.DB.GIAO_VIEN);



            GradeStudentCollection = new SeriesCollection()
            {
                new PieSeries
                {
                    Title="Khối 10",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(STUDENTLIST.Where(x=>x.LOP!= null &&  x.LOP.KHOI_LOP.MA_KHOI_LOP == 1).Count()) }, // Số lượng học sinh, chart sẽ tự tính %
                    DataLabels=true
                },

                new PieSeries
                {
                    Title="Khối 11",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(STUDENTLIST.Where(x => x.LOP != null && x.LOP.KHOI_LOP.MA_KHOI_LOP == 2 ).Count()) }, // Số lượng học sinh, chart sẽ tự tính %
                    DataLabels=true
                },

                new PieSeries
                {
                    Title="Khối 12",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(STUDENTLIST.Where(x => x.LOP != null && x.LOP.KHOI_LOP.MA_KHOI_LOP == 3).Count()) }, // Số lượng học sinh, chart sẽ tự tính %
                    DataLabels=true
                }
            };


            CLASSLIST = new ObservableCollection<LOP>(DataProvider.Ins.DB.LOPs.Where(x => x.MA_NAM_HOC == CurrentSemester.MA_NAM_HOC));
            GradeCollection = new SeriesCollection()
            {
                new PieSeries
                {
                    Title="Khối 10",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(CLASSLIST.Where(x=>x.KHOI_LOP.MA_KHOI_LOP == 1).Count()) }, // Số lượng học sinh, chart sẽ tự tính %
                    DataLabels=true
                },

                new PieSeries
                {
                    Title="Khối 11",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(CLASSLIST.Where(x => x.KHOI_LOP.MA_KHOI_LOP == 2).Count()) }, // Số lượng học sinh, chart sẽ tự tính %
                    DataLabels=true
                },

                new PieSeries
                {
                    Title="Khối 12",
                    FontSize=20,
                    Values=new ChartValues<ObservableValue> {new ObservableValue(CLASSLIST.Where(x => x.KHOI_LOP.MA_KHOI_LOP == 3).Count()) }, // Số lượng học sinh, chart sẽ tự tính %
                    DataLabels=true
                }
            };
        }
    }
}
