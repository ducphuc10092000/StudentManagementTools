using StudentManagement.Model;
using StudentManagement.Model.MARK;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StudentManagement.ViewModel.Mark_Manage_ViewModel
{
    public class EditMark_WD_ViewModel : BaseViewModel
    {
        private ObservableCollection<DIEM> _MARKLIST;
        public ObservableCollection<DIEM> MARKLIST { get => _MARKLIST; set { _MARKLIST = value; OnPropertyChanged(); } }

        private STUDENT_MARK _SelectedStudentMark;
        public STUDENT_MARK SelectedStudentMark { get => _SelectedStudentMark; set { _SelectedStudentMark = value; OnPropertyChanged(); } }

        private string _StudentName;
        public string StudentName { get => _StudentName; set { _StudentName = value; OnPropertyChanged(); } }

        private string _SubjectName;
        public string SubjectName { get => _SubjectName; set { _SubjectName = value; OnPropertyChanged(); } }
        private string _SemesterName;
        public string SemesterName { get => _SemesterName; set { _SemesterName = value; OnPropertyChanged(); } }

        private string _SchoolYear;
        public string SchoolYear { get => _SchoolYear; set { _SchoolYear = value; OnPropertyChanged(); } }
        private string _regularReviewScore;
        public string regularReviewScore { get => _regularReviewScore; set { _regularReviewScore = value; OnPropertyChanged(); } }
        private string _midTermScore;
        public string midTermScore { get => _midTermScore; set { _midTermScore = value; OnPropertyChanged(); } }
        private string _endTermScore;
        public string endTermScore { get => _endTermScore; set { _endTermScore = value; OnPropertyChanged(); } }

        public ICommand ConfirmEditStudentMarkCommand { get; set; }
        public ICommand QuitCommand { get; set; }


        public EditMark_WD_ViewModel()
        {
            ConfirmEditStudentMarkCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {

                //Tạo điểm mới
                string[] arrListRegularScore = regularReviewScore.Split(' ');
                foreach (var item in arrListRegularScore)
                {
                    if(Convert.ToDouble(item) < 0)
                    {
                        MessageBox.Show("Điểm đánh giá thường xuyên không thể nhỏ hơn 0","Thông báo",MessageBoxButton.OK,MessageBoxImage.Warning);
                        return;
                    }    
                    if(Convert.ToDouble(item) > 10)
                    {
                        MessageBox.Show("Điểm đánh giá thường xuyên không thể lớn hơn 10", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                //Check Input Tại đây
                if (Convert.ToDouble(midTermScore) < 0 )
                {
                    MessageBox.Show("Điểm giữa kỳ không thể nhỏ hơn 0", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if(Convert.ToDouble(midTermScore) > 10)
                {
                    MessageBox.Show("Điểm giữa kỳ không thể lớn hơn 10", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (Convert.ToDouble(endTermScore) < 0)
                {
                    MessageBox.Show("Điểm cuối kỳ không thể nhỏ hơn 0", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (Convert.ToDouble(endTermScore) > 10)
                {
                    MessageBox.Show("Điểm cuối kỳ không thể lớn hơn 10", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                MARKLIST = new ObservableCollection<DIEM>(DataProvider.Ins.DB.DIEMs.Where(x=>x.MA_QTMH == SelectedStudentMark.qt_hoc_mon_hoc.MA_QTMH && x.MA_MON_HOC == SelectedStudentMark.qt_hoc_mon_hoc.MA_MON_HOC));

                //Xóa điểm cũ
                foreach (var item in MARKLIST)
                {
                    DataProvider.Ins.DB.DIEMs.Remove(item);
                    DataProvider.Ins.DB.SaveChanges();

                }


                foreach(var item in arrListRegularScore)
                {
                    MARK tempMark = new MARK();
                    tempMark.AddNewMark(SelectedStudentMark.qt_hoc_mon_hoc.MA_QTMH, Convert.ToInt32(SelectedStudentMark.qt_hoc_mon_hoc.MA_MON_HOC), 1, Convert.ToDouble(item)) ;
                }

                MARK tempMarkMidTerm = new MARK();
                tempMarkMidTerm.AddNewMark(SelectedStudentMark.qt_hoc_mon_hoc.MA_QTMH, Convert.ToInt32(SelectedStudentMark.qt_hoc_mon_hoc.MA_MON_HOC), 2, Convert.ToDouble(midTermScore));

                MARK tempMarkEndTerm = new MARK();
                tempMarkEndTerm.AddNewMark(SelectedStudentMark.qt_hoc_mon_hoc.MA_QTMH, Convert.ToInt32(SelectedStudentMark.qt_hoc_mon_hoc.MA_MON_HOC), 3, Convert.ToDouble(endTermScore));
                MessageBox.Show("Chỉnh sửa điểm thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                p.Close();

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

        public void LoadSelectedStudentMark()
        {
            StudentName = SelectedStudentMark.qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.HOC_SINH.HO_TEN;
            SubjectName = SelectedStudentMark.qt_hoc_mon_hoc.MON_HOC.TEN_MON_HOC;
            SemesterName = SelectedStudentMark.qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.HOC_KY.TEN_HOC_KY;
            SchoolYear = SelectedStudentMark.qt_hoc_mon_hoc.QUA_TRINH_HOC_HOC_KY.HOC_KY.NAM_HOC.TEN_NAM_HOC;
            regularReviewScore = SelectedStudentMark.regular_review_score;
            midTermScore = SelectedStudentMark.midterm_score;
            endTermScore = SelectedStudentMark.endterm_score;
        }    
    }
}
