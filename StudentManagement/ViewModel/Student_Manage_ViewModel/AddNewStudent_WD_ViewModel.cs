﻿using Microsoft.Win32;
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
using System.Windows.Media;

namespace StudentManagement.ViewModel.Student_Manage_ViewModel
{
    public class AddNewStudent_WD_ViewModel : BaseViewModel
    {
        #region Binding COMBOBOX
        private ObservableCollection<TON_GIAO> _RELIGIONLIST;
        public ObservableCollection<TON_GIAO> RELIGIONLIST { get => _RELIGIONLIST; set { _RELIGIONLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _ReligionList;
        public ObservableCollection<string> ReligionList { get => _ReligionList; set { _ReligionList = value; OnPropertyChanged(); } }
        private ObservableCollection<DAN_TOC> _ETHNICITYLIST;
        public ObservableCollection<DAN_TOC> ETHNICITYLIST { get => _ETHNICITYLIST; set { _ETHNICITYLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _EthnicityList;
        public ObservableCollection<string> EthnicityList { get => _EthnicityList; set { _EthnicityList = value; OnPropertyChanged(); } }

        private ObservableCollection<QUOC_TICH> _NATIONALITYLIST;
        public ObservableCollection<QUOC_TICH> NATIONALITYLIST { get => _NATIONALITYLIST; set { _NATIONALITYLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _NationalityList;
        public ObservableCollection<string> NationalityList { get => _NationalityList; set { _NationalityList = value; OnPropertyChanged(); } }
        #endregion
        #region Bingding TEXT AddNewStudent_WD
        private string _SelectedStudentBirthday;
        public string SelectedStudentBirthday { get => _SelectedStudentBirthday; set { _SelectedStudentBirthday = value; OnPropertyChanged(); } }

        private string _StudentName;
        public string StudentName { get => _StudentName; set { _StudentName = value; OnPropertyChanged(); } }

        private string _StudentGender;
        public string StudentGender { get => _StudentGender; set { _StudentGender = value; OnPropertyChanged(); } }

        private string _StudentBirthday;
        public string StudentBirthday { get => _StudentBirthday; set { _StudentBirthday = value; OnPropertyChanged(); } }

        private string _StudentNationality;
        public string StudentNationality { get => _StudentNationality; set { _StudentNationality = value; OnPropertyChanged(); } }

        private string _StudentEthnicity;
        public string StudentEthnicity { get => _StudentEthnicity; set { _StudentEthnicity = value; OnPropertyChanged(); } }

        private string _StudentReligion;
        public string StudentReligion { get => _StudentReligion; set { _StudentReligion = value; OnPropertyChanged(); } }

        private string _StudentDadName;
        public string StudentDadName { get => _StudentDadName; set { _StudentDadName = value; OnPropertyChanged(); } }

        private string _StudentMomName;
        public string StudentMomName { get => _StudentMomName; set { _StudentMomName = value; OnPropertyChanged(); } }

        private string _StudentPhoneNumber;
        public string StudentPhoneNumber { get => _StudentPhoneNumber; set { _StudentPhoneNumber = value; OnPropertyChanged(); } }
        private string _ParentPhoneNumber;
        public string ParentPhoneNumber { get => _ParentPhoneNumber; set { _ParentPhoneNumber = value; OnPropertyChanged(); } }
        private string _StudentAddress;
        public string StudentAddress { get => _StudentAddress; set { _StudentAddress = value; OnPropertyChanged(); } }
        private ImageSource _AvatarSource;
        public ImageSource AvatarSource { get => _AvatarSource; set { _AvatarSource = value; OnPropertyChanged(); } }

        private string _Avatar;
        public string Avatar { get => _Avatar; set { _Avatar = value; OnPropertyChanged(); } }
        #endregion

        #region Binding TEXT EditStudent_WD
        private int _SelectedStudentID;
        public int SelectedStudentID { get => _SelectedStudentID; set { _SelectedStudentID = value; OnPropertyChanged(); } }
        #endregion

        #region Binding Command BUTTON
        public ICommand Open_AddNewNationality_WD_Command { get; set; }
        public ICommand Open_AddNewEthnicity_WD_Command { get; set; }
        public ICommand AddNewStudentCommand { get; set; }
        public ICommand QuitCommand { get; set; }
        public ICommand ChangePictureCommand { get; set; }
        public ICommand DeletePictureCommand { get; set; }
        #endregion

        #region Binding Command EditStudent
        public ICommand ConfirmEditStudentCommand { get; set; }
        #endregion 
        public AddNewStudent_WD_ViewModel()
        {
            ResetTextbox();
            LoadNationalityListToCombobox();
            LoadEthnicityListToCombobox();
            LoadReligionListToCombobox();

            #region Handling Command AddNewStudent
            AddNewStudentCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                //Check Input Tại đây
                //if()
                //{

                //}    
                STUDENT new_Student = new STUDENT();
                DAN_TOC selected_Ethnicity = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == StudentEthnicity).SingleOrDefault();
                QUOC_TICH selected_Nationality = DataProvider.Ins.DB.QUOC_TICH.Where(x => x.TEN_QUOC_TICH == StudentNationality).SingleOrDefault();
                new_Student.AddNewStudent(StudentName,StudentGender,StudentBirthday,StudentEthnicity,StudentNationality,StudentReligion,StudentDadName,StudentMomName,StudentPhoneNumber,ParentPhoneNumber,StudentAddress,Avatar);

                Student_UC student_UC = new Student_UC();
                var student_UC_DT = student_UC.DataContext as Student_UC_ViewModel;
                student_UC_DT.LoadStudentList();

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
            ChangePictureCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    InitialDirectory = @"C:\",
                    Title = "Chọn ảnh đại diện",

                    CheckFileExists = true,
                    CheckPathExists = true,

                    DefaultExt = "txt",
                    Filter = "Images (*.JPG;*.PNG)|*.JPG;*.PNG",
                    RestoreDirectory = true,
                    ReadOnlyChecked = true,
                    ShowReadOnly = true
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    Avatar = ImageProvider.ImageToString(openFileDialog.FileName);
                    AvatarSource = ImageProvider.GetImage(Avatar);
                }

            });
            DeletePictureCommand = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AvatarSource = null;
                Avatar = null;
            });
            #endregion

            #region Handling Command EditStudent
            ConfirmEditStudentCommand = new RelayCommand<Window>((p) =>
            {
                //if (AccountPower == 0 || AccountPower == 1)
                //{
                //    MessageBoxResult result = MessageBox.Show("Bạn không đủ quyền truy cập vào chức năng này!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                //    return false;
                //}


                return true;
            }, (p) =>
            {
                //Check Input Tại đây
                //if()
                //{

                //}    
                STUDENT selected_Student = new STUDENT();

                DAN_TOC selected_Ethnicity = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == StudentEthnicity).SingleOrDefault();
                QUOC_TICH selected_Nationality = DataProvider.Ins.DB.QUOC_TICH.Where(x => x.TEN_QUOC_TICH == StudentNationality).SingleOrDefault();

                selected_Student.EditStudent(SelectedStudentID, StudentName, StudentGender, StudentBirthday, StudentEthnicity, StudentNationality, StudentReligion, StudentDadName, StudentMomName, StudentPhoneNumber, ParentPhoneNumber, StudentAddress, Avatar);

                Student_UC student_UC = new Student_UC();
                var student_UC_DT = student_UC.DataContext as Student_UC_ViewModel;
                student_UC_DT.LoadStudentList();

                p.Close();
            });
            #endregion
        }
        public void ResetTextbox()
        {
            SelectedStudentBirthday = null;
            StudentName = "";
            StudentGender = "";
            StudentBirthday = "";
            StudentNationality = "";
            StudentEthnicity = "";
            StudentDadName = "";
            StudentMomName = "";
            StudentPhoneNumber = "";
            ParentPhoneNumber = "";
            StudentAddress = "";
            Avatar = "";
            AvatarSource = null;
        }

        public void LoadNationalityListToCombobox()
        {
            NATIONALITYLIST = new ObservableCollection<QUOC_TICH>(DataProvider.Ins.DB.QUOC_TICH);
            NationalityList = new ObservableCollection<string>();
            foreach (var item in NATIONALITYLIST)
            {
                NationalityList.Add(item.TEN_QUOC_TICH);
            }
        }
        public void LoadReligionListToCombobox()
        {
            RELIGIONLIST = new ObservableCollection<TON_GIAO>(DataProvider.Ins.DB.TON_GIAO);
            ReligionList = new ObservableCollection<string>();
            foreach (var item in RELIGIONLIST)
            {
                ReligionList.Add(item.TEN_TON_GIAO);
            }
        }
        public void LoadEthnicityListToCombobox()
        {
            ETHNICITYLIST = new ObservableCollection<DAN_TOC>(DataProvider.Ins.DB.DAN_TOC);
            EthnicityList = new ObservableCollection<string>();
            foreach (var item in ETHNICITYLIST)
            {
                EthnicityList.Add(item.TEN_DAN_TOC);
            }
        }

        public void LoadSelectedStudent(int id_student)
        {
            SelectedStudentID = id_student;
            STUDENT selected_STUDENT = new STUDENT();
            selected_STUDENT.hocsinh = DataProvider.Ins.DB.HOC_SINH.Where(x => x.MA_HOC_SINH == id_student).SingleOrDefault();
            StudentName = selected_STUDENT.hocsinh.HO_TEN;
            StudentGender = selected_STUDENT.hocsinh.GIOI_TINH;
            StudentBirthday = selected_STUDENT.hocsinh.NGAY_SINH.ToString();
            StudentAddress = selected_STUDENT.hocsinh.DIA_CHI;
            StudentEthnicity = selected_STUDENT.hocsinh.DAN_TOC.TEN_DAN_TOC;
            StudentNationality = selected_STUDENT.hocsinh.QUOC_TICH.TEN_QUOC_TICH;
            StudentReligion = selected_STUDENT.hocsinh.TON_GIAO.TEN_TON_GIAO;
            StudentPhoneNumber = selected_STUDENT.hocsinh.SO_DIEN_THOAI;
            ParentPhoneNumber = selected_STUDENT.hocsinh.SDT_PHU_HUYNH;
            StudentMomName = selected_STUDENT.hocsinh.HO_TEN_ME;
            StudentDadName = selected_STUDENT.hocsinh.HO_TEN_CHA;
            Avatar = selected_STUDENT.hocsinh.AVATAR;

            if (string.IsNullOrEmpty(Avatar))
            {
                AvatarSource = null;
            }
            else
            {
                AvatarSource = ImageProvider.GetImage(Avatar);
            }
        }
    }
}
