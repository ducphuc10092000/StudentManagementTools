using StudentManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Model.MARK
{
    public class STUDENT_MARK : BaseViewModel
    {
        private ObservableCollection<DIEM> _MARKLIST;
        public ObservableCollection<DIEM> MARKLIST { get => _MARKLIST; set { _MARKLIST = value; OnPropertyChanged(); } }

        public QUA_TRINH_HOC_MON_HOC qt_hoc_mon_hoc { get; set; }

        private string _regular_review_score;
        public string regular_review_score { get => _regular_review_score; set { _regular_review_score = value; OnPropertyChanged(); } }

        private string _midterm_score;
        public string midterm_score { get => _midterm_score; set { _midterm_score = value; OnPropertyChanged(); } }

        private string _endterm_score;
        public string endterm_score { get => _endterm_score; set { _endterm_score = value; OnPropertyChanged(); } }

        private string _medium_score;
        public string medium_score { get => _medium_score; set { _medium_score = value; OnPropertyChanged(); } }

        public STUDENT_MARK()
        {
           
        }
        public void LoadScore()
        {
            MARKLIST = new ObservableCollection<DIEM>();
            if (qt_hoc_mon_hoc != null)
            {
                MARKLIST = new ObservableCollection<DIEM>(DataProvider.Ins.DB.DIEMs.Where(x => x.MA_QTMH == qt_hoc_mon_hoc.MA_QTMH));
            }


            int regular_score_quantity = new int();
            regular_score_quantity = 0;

            double sumaryy_score_temp = new double();
            sumaryy_score_temp = 0;
            if (MARKLIST.Count() != 0)
            {
                foreach (var item in MARKLIST)
                {
                    if (item.MA_LOAI_DIEM == 1)
                    {
                        if(string.IsNullOrEmpty(regular_review_score))
                        {
                            regular_review_score +=item.DIEM_SO.ToString();
                        }    
                        else
                        {
                            regular_review_score += " " + item.DIEM_SO.ToString();
                        }    

                        regular_score_quantity += 1;
                        sumaryy_score_temp += Convert.ToDouble(item.DIEM_SO);
                    }
                    if (item.MA_LOAI_DIEM == 2)
                    {
                        midterm_score = item.DIEM_SO.ToString();
                        sumaryy_score_temp += Convert.ToDouble(item.DIEM_SO) * 2;
                    }
                    if (item.MA_LOAI_DIEM == 3)
                    {
                        endterm_score = item.DIEM_SO.ToString();
                        sumaryy_score_temp += Convert.ToDouble(item.DIEM_SO) * 3; 
                    }
                    
                }
            }

            medium_score = (sumaryy_score_temp / (regular_score_quantity + 5)).ToString();

        }    
    }
}
