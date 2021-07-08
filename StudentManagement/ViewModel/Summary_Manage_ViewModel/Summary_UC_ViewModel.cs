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
        #region COMMAND SchoolYear Summary
        public ICommand ConfirmSchoolYearSummaryCommand { get; set; }
        public ICommand FindSchoolYearProcessCommand { get; set; }
        public ICommand Open_StudentDetailSchoolYearProcess_WD_Command { get; set; }
        public ICommand Quit_EditSummarySchoolYear_WD_Command { get; set; }
        #endregion

        #region COMMAND Semester Summary
        public ICommand FindCommand { get; set; }

        public ICommand DefaultCommand { get; set; }

        public ICommand ExportExcelFileCommand { get; set; }

        public ICommand Open_StudentDetailMark_WD_Command { get; set; }

        public ICommand Open_EditStudentMark_WD_Command { get; set; }
        public ICommand QuitCommand { get; set; }
        public ICommand ConfirmEditStudentMarkSummaryCommand { get; set; }
        #endregion


        #region TEXT binding SEMESTER SUMMARY
        private string _SelectedMediumMark;
        public string SelectedMediumMark { get => _SelectedMediumMark; set { _SelectedMediumMark = value; OnPropertyChanged(); } }

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


        #endregion

        #region TEXT Binding SCHOOLYEAR PROCESS
        private string _SelectedStudent_SchoolYear_Process_Conduct;
        public string SelectedStudent_SchoolYear_Process_Conduct { get => _SelectedStudent_SchoolYear_Process_Conduct; set { _SelectedStudent_SchoolYear_Process_Conduct = value; OnPropertyChanged(); } }
        

        private double _SelectedStudent_SchoolYear_Process_MediumScore;
        public double SelectedStudent_SchoolYear_Process_MediumScore { get => _SelectedStudent_SchoolYear_Process_MediumScore; set { _SelectedStudent_SchoolYear_Process_MediumScore = value; OnPropertyChanged(); } }

        private string _SchoolYearSummaryResult;
        public string SchoolYearSummaryResult { get => _SchoolYearSummaryResult; set { _SchoolYearSummaryResult = value; OnPropertyChanged(); } }
        
        private ObservableCollection<QUA_TRINH_HOC_NAM_HOC> _SCHOOLYEAR_PROCESS_LIST;
        public ObservableCollection<QUA_TRINH_HOC_NAM_HOC> SCHOOLYEAR_PROCESS_LIST { get => _SCHOOLYEAR_PROCESS_LIST; set { _SCHOOLYEAR_PROCESS_LIST = value; OnPropertyChanged(); } }

        private ObservableCollection<QUA_TRINH_HOC_NAM_HOC> _SCHOOLYEAR_PROCESS_LIST_DTG;
        public ObservableCollection<QUA_TRINH_HOC_NAM_HOC> SCHOOLYEAR_PROCESS_LIST_DTG { get => _SCHOOLYEAR_PROCESS_LIST_DTG; set { _SCHOOLYEAR_PROCESS_LIST_DTG = value; OnPropertyChanged(); } }

        private QUA_TRINH_HOC_NAM_HOC _SelectedStudent_SchoolYear_Process;
        public QUA_TRINH_HOC_NAM_HOC SelectedStudent_SchoolYear_Process { get => _SelectedStudent_SchoolYear_Process; set { _SelectedStudent_SchoolYear_Process = value; OnPropertyChanged(); } }
        #endregion

        public Summary_UC_ViewModel()
        {
            SelectedStudent_SchoolYear_Process = new QUA_TRINH_HOC_NAM_HOC();
            LoadCombobox();

            #region HANDLING COMMAND SCHOOLYEAR SUMMARY
            ConfirmSchoolYearSummaryCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                TongKetNamHoc();
                MessageBox.Show("Xếp loại học sinh thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            });
            FindSchoolYearProcessCommand = new RelayCommand<object>((p) =>
            {

                return true;
            }, (p) =>
            {
                LoadSchoolYearProcessList();
            });

            Open_StudentDetailSchoolYearProcess_WD_Command = new RelayCommand<object>((p) =>
            {

                return true;
            }, (p) =>
            {
                LoadSemesterProcessListInSchoolYear();

                EditSummary_SchoolYear_WD editSummary_SchoolYear_WD = new EditSummary_SchoolYear_WD();
                editSummary_SchoolYear_WD.ShowDialog();
                editSummary_SchoolYear_WD.Close();


                LoadSchoolYearProcessList();

            });
            Quit_EditSummarySchoolYear_WD_Command = new RelayCommand<Window>((p) =>
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
                    LoadSchoolYearProcessList();
                    p.Close();
                }
                else
                {
                    return;
                }
            });
            #endregion


            #region HANDLING COMMAND SEMESTER SUMMARY
            ConfirmEditStudentMarkSummaryCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                if (string.IsNullOrEmpty(SelectedConduct))
                {
                    MessageBox.Show("Hạnh kiểm chưa được chọn, không thể xếp loại học sinh!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                SelectedStudent_Semester_Process.HANH_KIEM = DataProvider.Ins.DB.HANH_KIEM.Where(x => x.TEN_HANH_KIEM == SelectedConduct).SingleOrDefault();
                DataProvider.Ins.DB.SaveChanges();

                //LIST QUÁ TRÌNH HỌC MÔN HỌC -> LẤY ĐIỂM TRUNG BÌNH MÔN ĐÓ RA ĐỂ CHECK
                ObservableCollection<QUA_TRINH_HOC_MON_HOC> tempQTHMH = new ObservableCollection<QUA_TRINH_HOC_MON_HOC>(DataProvider.Ins.DB.QUA_TRINH_HOC_MON_HOC.Where(x => x.MA_QTHK == SelectedStudent_Semester_Process.MA_QTHK));
                foreach (var qthmh in tempQTHMH)
                {
                    if (string.IsNullOrEmpty(qthmh.DIEM_TB_MON_HOC.ToString()) || qthmh.DIEM_TB_MON_HOC == 0)
                    {
                        MessageBox.Show("Điểm chưa đủ, không thể xếp loại học sinh!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }

                DanhGiaHocLuc();
                XepLoaiHocSinh();
                DataProvider.Ins.DB.SaveChanges();
                SummaryResult = SelectedStudent_Semester_Process.XEP_LOAI.TEN_XEP_LOAI;
                MessageBox.Show("Xếp loại học sinh thành công!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
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
                    LoadSemesterProcessList();
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
                LoadSemesterProcessList();

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
            #endregion


        }


        public void LoadSemesterProcessListInSchoolYear()
        {
            SEMESTER_PROCESS_LIST = new ObservableCollection<QUA_TRINH_HOC_HOC_KY>(DataProvider.Ins.DB.QUA_TRINH_HOC_HOC_KY.Where(x => x.MA_QTNH == SelectedStudent_SchoolYear_Process.MA_QTNH && x.MA_LOP == SelectedStudent_SchoolYear_Process.MA_LOP));

            SEMESTER_PROCESS_LIST_DTG = new ObservableCollection<QUA_TRINH_HOC_HOC_KY>();
            foreach (var item in SEMESTER_PROCESS_LIST)
            {
                item.DIEM_TB = Math.Round(Convert.ToDouble(item.DIEM_TB), 2);
                SEMESTER_PROCESS_LIST_DTG.Add(item);
            }

            if(SelectedStudent_SchoolYear_Process.MA_XEP_LOAI != null)
            {
                SchoolYearSummaryResult = SelectedStudent_SchoolYear_Process.XEP_LOAI.TEN_XEP_LOAI;
            }    
            if(SelectedStudent_SchoolYear_Process.MA_HANH_KIEM != null)
            {
                SelectedStudent_SchoolYear_Process_Conduct = SelectedStudent_SchoolYear_Process.HANH_KIEM.TEN_HANH_KIEM;
            }    
            SelectedStudent_SchoolYear_Process_MediumScore = Convert.ToDouble(SelectedStudent_SchoolYear_Process.DIEM_TB);
            
            
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

            //CheckFrom EDITSUMMARY_SCHOOLYEAR_WD
            if(SelectedStudent_Semester_Process != null)
            {
                selectedSemester = new HOC_KY();
                selectedSemester = DataProvider.Ins.DB.HOC_KY.Where(x => x.MA_HOC_KY == SelectedStudent_Semester_Process.MA_HOC_KY).SingleOrDefault();
                SelectedSemester = selectedSemester.TEN_HOC_KY;            
            }    

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
                item.DIEM_TB = Math.Round(Convert.ToDouble(item.DIEM_TB), 2);
                SEMESTER_PROCESS_LIST_DTG.Add(item);
            }    
        }

        public void LoadSchoolYearProcessList()
        {
            NAM_HOC selectedSchoolYear = new NAM_HOC();
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
            if (!string.IsNullOrEmpty(SelectedClassName))
            {
                selectedClass = DataProvider.Ins.DB.LOPs.Where(x => x.TEN_LOP == SelectedClassName && x.MA_NAM_HOC == selectedSchoolYear.MA_NAM_HOC).SingleOrDefault();
            }
            else
            {
                MessageBox.Show("Chưa chọn lớp học!");
                return;
            }

            SCHOOLYEAR_PROCESS_LIST = new ObservableCollection<QUA_TRINH_HOC_NAM_HOC>(DataProvider.Ins.DB.QUA_TRINH_HOC_NAM_HOC.Where(x => x.LOP.MA_NAM_HOC == selectedSchoolYear.MA_NAM_HOC && x.MA_LOP == selectedClass.MA_LOP));
            SCHOOLYEAR_PROCESS_LIST_DTG = new ObservableCollection<QUA_TRINH_HOC_NAM_HOC>();
            foreach (var item in SCHOOLYEAR_PROCESS_LIST)
            {
                item.DIEM_TB = Math.Round(Convert.ToDouble(item.DIEM_TB), 2);
                SCHOOLYEAR_PROCESS_LIST_DTG.Add(item);
            }
        }

        public void DanhGiaHocLuc()
        {
            SelectedStudent_Semester_Process.HANH_KIEM = DataProvider.Ins.DB.HANH_KIEM.Where(x => x.TEN_HANH_KIEM == SelectedConduct).SingleOrDefault();

            //LIST QUÁ TRÌNH HỌC MÔN HỌC -> LẤY ĐIỂM TRUNG BÌNH MÔN ĐÓ RA ĐỂ CHECK
            ObservableCollection<QUA_TRINH_HOC_MON_HOC> tempQTHMH = new ObservableCollection<QUA_TRINH_HOC_MON_HOC>(DataProvider.Ins.DB.QUA_TRINH_HOC_MON_HOC.Where(x => x.MA_QTHK == SelectedStudent_Semester_Process.MA_QTHK));


            foreach (var qthmh in tempQTHMH)
            {
                //Diem toan || ngu van || ngoai ngu >= 8 -> co the la hoc sinh gioi
                if (qthmh.DIEM_TB_MON_HOC >= 8 && (qthmh.MON_HOC.TEN_MON_HOC == "Toán" || qthmh.MON_HOC.TEN_MON_HOC == "Ngữ văn" || qthmh.MON_HOC.TEN_MON_HOC=="Ngoại ngữ"))
                {
                    //Diem trung binh hoc ky >= 8
                    if (SelectedStudent_Semester_Process.DIEM_TB >= 8)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 5)
                            {
                                // Xếp loại trung bình
                                SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 6.5)
                            {
                                // Xếp loại khá
                                SelectedStudent_Semester_Process.HOC_LUC = "Khá";
                                return;
                            }
                        }
                        //Không xảy ra trường hợp nào ở trên -> tất cả các môn đều > 6.5
                        // -> học lực giỏi
                        SelectedStudent_Semester_Process.HOC_LUC = "Giỏi";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 6.5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 5)
                            {
                                // Xếp loại trung bình
                                SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                                return;
                            }
                        }
                        // Xếp loại khá
                        SelectedStudent_Semester_Process.HOC_LUC = "Khá";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại học lực kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại học lực yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                        }
                        // Xếp loại học lực trung bình
                        SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 3.5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại học lực kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                        }
                        // Xếp loại học lực yếu
                        SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                        return;
                    }
                    // Điểm tb môn từ 0 <= x < 3.5
                    else
                    {
                        // Xếp loại học lực kém
                        SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                        return;
                    }
                }
            }

            //Loop 6.5 -> 8
            foreach(var qthmh in tempQTHMH)
            {
                if ((qthmh.MON_HOC.TEN_MON_HOC == "Toán" || qthmh.MON_HOC.TEN_MON_HOC == "Ngữ văn" || qthmh.MON_HOC.TEN_MON_HOC == "Ngoại ngữ") && qthmh.DIEM_TB_MON_HOC >= 6.5)
                {
                    //Diem trung binh hoc ky >= 8
                    if (SelectedStudent_Semester_Process.DIEM_TB >= 8)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 5)
                            {
                                // Xếp loại trung bình
                                SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                                return;
                            }
                        }
                        //Không xảy ra trường hợp nào ở trên -> tất cả các môn đều > 5
                        // Xếp loại học lực khá
                        SelectedStudent_Semester_Process.HOC_LUC = "Khá";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 6.5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 5)
                            {
                                // Xếp loại trung bình
                                SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                                return;
                            }
                        }
                        // Xếp loại khá
                        SelectedStudent_Semester_Process.HOC_LUC = "Khá";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại học lực kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại học lực yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                        }
                        // Xếp loại học lực trung bình
                        SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 3.5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại học lực kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                        }
                        // Xếp loại học lực yếu
                        SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                        return;
                    }
                    // Điểm tb môn từ 0 <= x < 3.5
                    else
                    {
                        // Xếp loại học lực kém
                        SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                        return;
                    }
                }
            }   
            
            //Loop 5-> 6.5
            foreach(var qthmh in tempQTHMH)
            {
                if ((qthmh.MON_HOC.TEN_MON_HOC == "Toán" || qthmh.MON_HOC.TEN_MON_HOC == "Ngữ văn" || qthmh.MON_HOC.TEN_MON_HOC == "Ngoại ngữ") && qthmh.DIEM_TB_MON_HOC >= 5)
                {
                    //Diem trung binh hoc ky >= 8
                    if (SelectedStudent_Semester_Process.DIEM_TB >= 8)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                        }
                        //Không xảy ra trường hợp nào ở trên -> tất cả các môn đều > 5
                        // Xếp loại trung bình
                        SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 6.5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                        }

                        // Xếp loại trung bình
                        SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại học lực kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại học lực yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                        }
                        // Xếp loại học lực trung bình
                        SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 3.5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại học lực kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                        }
                        // Xếp loại học lực yếu
                        SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                        return;
                    }
                    // Điểm tb môn từ 0 <= x < 3.5
                    else
                    {
                        // Xếp loại học lực kém
                        SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                        return;
                    }
                }
            }    

            //Loop < 5
            foreach(var qthmh in tempQTHMH)
            {
                 if ((qthmh.MON_HOC.TEN_MON_HOC == "Toán" || qthmh.MON_HOC.TEN_MON_HOC == "Ngữ văn" || qthmh.MON_HOC.TEN_MON_HOC == "Ngoại ngữ") && qthmh.DIEM_TB_MON_HOC < 5)
                {
                    //Diem trung binh hoc ky >= 8
                    if (SelectedStudent_Semester_Process.DIEM_TB >= 8)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                        }
                        //Không xảy ra trường hợp nào ở trên -> tất cả các môn đều > 5
                        // Xếp loại trung bình
                        SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 6.5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                        }

                        // Xếp loại trung bình
                        SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại học lực kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                            else if (other_qthmh.DIEM_TB_MON_HOC < 3.5)
                            {
                                // Xếp loại học lực yếu
                                SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                                return;
                            }
                        }
                        // Xếp loại học lực trung bình
                        SelectedStudent_Semester_Process.HOC_LUC = "Trung bình";
                        return;
                    }
                    else if (SelectedStudent_Semester_Process.DIEM_TB >= 3.5)
                    {
                        //Loop kiểm tra xem điểm trung bình của những môn còn lại
                        foreach (var other_qthmh in tempQTHMH)
                        {
                            if (other_qthmh.DIEM_TB_MON_HOC < 2)
                            {
                                // Xếp loại học lực kém
                                SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                                return;
                            }
                        }
                        // Xếp loại học lực yếu
                        SelectedStudent_Semester_Process.HOC_LUC = "Yếu";
                        return;
                    }
                    // Điểm tb môn từ 0 <= x < 3.5
                    else
                    {
                        // Xếp loại học lực kém
                        SelectedStudent_Semester_Process.HOC_LUC = "Kém";
                        return;
                    }
                }
            }    
        }
        public void XepLoaiHocSinh()
        {
            if(SelectedStudent_Semester_Process.HOC_LUC == "Giỏi")
            {
                if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Tốt")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 1;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Khá")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 2;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Trung bình")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 3;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Yếu")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 4;
                    return;
                }
            }    
            else if(SelectedStudent_Semester_Process.HOC_LUC == "Khá")
            {

                if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Tốt")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 2;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Khá")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 2;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Trung bình")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 3;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Yếu")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 4;
                    return;
                }
            }
            else if (SelectedStudent_Semester_Process.HOC_LUC == "Trung bình")
            {

                if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Tốt")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 3;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Khá")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 3;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Trung bình")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 3;
                    return;
                }
                else if (SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM == "Yếu")
                {
                    SelectedStudent_Semester_Process.MA_XEP_LOAI = 4;
                    return;
                }
            }
            else if (SelectedStudent_Semester_Process.HOC_LUC == "Yếu")
            {
                SelectedStudent_Semester_Process.MA_XEP_LOAI = 4;
                return;
            }
            else if (SelectedStudent_Semester_Process.HOC_LUC == "Kém")
            {
                SelectedStudent_Semester_Process.MA_XEP_LOAI = 5;
                return;
            }
        }    

        public void TongKetNamHoc()
        {
            SelectedStudent_SchoolYear_Process_MediumScore = 0;

            double temptotalscore = new double();
            temptotalscore = 0;
            foreach (var item in SEMESTER_PROCESS_LIST_DTG)
            {
                if(item.HOC_KY.TEN_HOC_KY == "Học kỳ 1")
                {
                    temptotalscore += Convert.ToDouble(item.DIEM_TB);
                }
                if (item.HOC_KY.TEN_HOC_KY == "Học kỳ 2")
                {
                    temptotalscore += 2 * Convert.ToDouble(item.DIEM_TB);
                }
            }
            SelectedStudent_SchoolYear_Process.DIEM_TB = temptotalscore / 3;
            SelectedStudent_SchoolYear_Process.HANH_KIEM = DataProvider.Ins.DB.HANH_KIEM.Where(x=>x.TEN_HANH_KIEM == SelectedStudent_SchoolYear_Process_Conduct).SingleOrDefault();

            if(SelectedStudent_SchoolYear_Process.DIEM_TB >= 8)
            {
                SelectedStudent_SchoolYear_Process.MA_XEP_LOAI = 1;
                DataProvider.Ins.DB.SaveChanges();
                return;
            }    
            else if(SelectedStudent_SchoolYear_Process.DIEM_TB >= 6.5)
            {
                SelectedStudent_SchoolYear_Process.MA_XEP_LOAI = 2;
                DataProvider.Ins.DB.SaveChanges();
                return;
            }
            else if (SelectedStudent_SchoolYear_Process.DIEM_TB >= 5)
            {
                SelectedStudent_SchoolYear_Process.MA_XEP_LOAI = 3;
                DataProvider.Ins.DB.SaveChanges();
                return;
            }
            else if (SelectedStudent_SchoolYear_Process.DIEM_TB >= 3.5)
            {
                SelectedStudent_SchoolYear_Process.MA_XEP_LOAI = 4;
                DataProvider.Ins.DB.SaveChanges();
                return;
            }
            else 
            {
                SelectedStudent_SchoolYear_Process.MA_XEP_LOAI = 5;
                DataProvider.Ins.DB.SaveChanges();
                return;
            }
        }
        public void LoadStudentMark()
        {
            STUDENTMARKLISTDTG = new ObservableCollection<STUDENT_MARK>();
            MARKLIST = new ObservableCollection<DIEM>();
            double tempDIEMTB = new double();
            tempDIEMTB = 0;

            //Load hạnh kiểm nếu có
            if(!string.IsNullOrEmpty(SelectedStudent_Semester_Process.MA_HANH_KIEM.ToString()))
            {
                SelectedConduct = SelectedStudent_Semester_Process.HANH_KIEM.TEN_HANH_KIEM.ToString();
            }    
            //Load xếp loại nếu có
            if(!string.IsNullOrEmpty(SelectedStudent_Semester_Process.MA_XEP_LOAI.ToString()))
            {
                SummaryResult = SelectedStudent_Semester_Process.XEP_LOAI.TEN_XEP_LOAI.ToString();
            }    


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
            SelectedStudent_Semester_Process.DIEM_TB = Math.Round(tempDIEMTB / tempQTHMH.Count(),2);

            SelectedMediumMark = SelectedStudent_Semester_Process.DIEM_TB.ToString();
            DataProvider.Ins.DB.SaveChanges();

        }

        public void ResetParaSemester()
        {
            SelectedSchoolYear = "";
            SelectedSemester = "";
            SelectedClassName = "";
            SelectedConduct = "";
            SEMESTER_PROCESS_LIST_DTG = new ObservableCollection<QUA_TRINH_HOC_HOC_KY>();
        }    
        public void ResetParaSchoolYear()
        {
            SelectedSchoolYear = "";
            SelectedClassName = "";
            SelectedConduct = "";
            SCHOOLYEAR_PROCESS_LIST_DTG = new ObservableCollection<QUA_TRINH_HOC_NAM_HOC>();
        }
    }
}
