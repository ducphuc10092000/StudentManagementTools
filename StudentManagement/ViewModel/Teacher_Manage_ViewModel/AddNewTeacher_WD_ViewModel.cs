<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ViewModel.Teacher_Manage_ViewModel
{
    class AddNewTeacher_WD_ViewModel
    {
    }
}
=======
﻿using Microsoft.Win32;
using StudentManagement.Model;
using StudentManagement.Model.TEACHER;
using StudentManagement.View.Teacher_Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace StudentManagement.ViewModel.Teacher_Manage_ViewModel
{
    public class AddNewTeacher_WD_ViewModel : BaseViewModel
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

        private ObservableCollection<BO_MON> _GROUPSUBJECTLIST;
        public ObservableCollection<BO_MON> GROUPSUBJECTLIST { get => _GROUPSUBJECTLIST; set { _GROUPSUBJECTLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _GroupSubjectListCbb;
        public ObservableCollection<string> GroupSubjectListCbb { get => _GroupSubjectListCbb; set { _GroupSubjectListCbb = value; OnPropertyChanged(); } }

        private ObservableCollection<TRINH_DO_HOC_VAN> _ACADEMICLEVELLIST;
        public ObservableCollection<TRINH_DO_HOC_VAN> ACADEMICLEVELLIST { get => _ACADEMICLEVELLIST; set { _ACADEMICLEVELLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _AcademicLevelListCbb;
        public ObservableCollection<string> AcademicLevelListCbb { get => _AcademicLevelListCbb; set { _AcademicLevelListCbb = value; OnPropertyChanged(); } }

        

        #endregion
        #region Bingding TEXT AddNewTeacher_WD
        private int _SelectedTeacherID;
        public int SelectedTeacherID { get => _SelectedTeacherID; set { _SelectedTeacherID = value; OnPropertyChanged(); } }

        private string _TeacherName;
        public string TeacherName { get => _TeacherName; set { _TeacherName = value; OnPropertyChanged(); } }

        private string _TeacherEmail;
        public string TeacherEmail { get => _TeacherEmail; set { _TeacherEmail = value; OnPropertyChanged(); } }

        private string _TeacherPhoneNumber;
        public string TeacherPhoneNumber { get => _TeacherPhoneNumber; set { _TeacherPhoneNumber = value; OnPropertyChanged(); } }

        private string _TeacherIdentifyNumber;
        public string TeacherIdentifyNumber { get => _TeacherIdentifyNumber; set { _TeacherIdentifyNumber = value; OnPropertyChanged(); } }
        

        private string _TeacherGender;
        public string TeacherGender { get => _TeacherGender; set { _TeacherGender = value; OnPropertyChanged(); } }

        private string _TeacherBirthday;
        public string TeacherBirthday { get => _TeacherBirthday; set { _TeacherBirthday = value; OnPropertyChanged(); } }

        private string _TeacherGroupSubject;
        public string TeacherGroupSubject { get => _TeacherGroupSubject; set { _TeacherGroupSubject = value; OnPropertyChanged(); } }

        private string _TeacherEthnicity;
        public string TeacherEthnicity { get => _TeacherEthnicity; set { _TeacherEthnicity = value; OnPropertyChanged(); } }

        private string _TeacherReligion;
        public string TeacherReligion { get => _TeacherReligion; set { _TeacherReligion = value; OnPropertyChanged(); } }
        private string _TeacherNationality;
        public string TeacherNationality { get => _TeacherNationality; set { _TeacherNationality = value; OnPropertyChanged(); } }

        

        private string _TeacherAddress;
        public string TeacherAddress { get => _TeacherAddress; set { _TeacherAddress = value; OnPropertyChanged(); } }

        private string _TeacherAcademicLevel;
        public string TeacherAcademicLevel { get => _TeacherAcademicLevel; set { _TeacherAcademicLevel = value; OnPropertyChanged(); } }

        private ImageSource _AvatarSource;
        public ImageSource AvatarSource { get => _AvatarSource; set { _AvatarSource = value; OnPropertyChanged(); } }

        private string _Avatar;
        public string Avatar { get => _Avatar; set { _Avatar = value; OnPropertyChanged(); } }
        #endregion

        #region Command AddNewTeacher_WD
        public ICommand QuitCommand { get; set; }
        public ICommand AddNewTeacherCommand { get; set; }
        public ICommand ChangePictureCommand { get; set; }
        public ICommand DeletePictureCommand { get; set; }
        #endregion

        #region Command EditTeacher_WD
        public ICommand ConfirmEditTeacherCommand { get; set; }
        #endregion
        public AddNewTeacher_WD_ViewModel()
        {
            LoadCombobox();

            #region Handling command
            QuitCommand = new RelayCommand<Window>((p) =>
            {

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

            #region Handling command AddNew
            AddNewTeacherCommand = new RelayCommand<Window>((p) =>
            {

                return true;
            }, (p) =>
            {
                TEACHER teacher = new TEACHER();

                //BO_MON selected_Subject = DataProvider.Ins.DB.BO_MON.Where(x => x.TEN_BO_MON == TeacherSubject);

                DAN_TOC ethnicity = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == TeacherEthnicity).SingleOrDefault();

                teacher.AddNewTeacher(TeacherName,TeacherBirthday, TeacherGender, TeacherPhoneNumber, TeacherEmail, TeacherAddress, TeacherReligion, TeacherEthnicity, TeacherNationality, TeacherGroupSubject, Avatar,  TeacherAcademicLevel, TeacherIdentifyNumber);

                Teacher_UC teacher_UC = new Teacher_UC();
                var teacher_UC_DT = teacher_UC.DataContext as Teacher_UC_ViewModel;
                teacher_UC_DT.LoadTeacherList();

                p.Close();
            });
            #endregion

            #region handling command EditTeacher
            ConfirmEditTeacherCommand = new RelayCommand<Window>((p) =>
            {

                return true;
            }, (p) =>
            {
                TEACHER selected_Teacher = new TEACHER();

                //BO_MON selected_Subject = DataProvider.Ins.DB.BO_MON.Where(x => x.TEN_BO_MON == TeacherSubject);

                DAN_TOC ethnicity = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == TeacherEthnicity).SingleOrDefault();

                selected_Teacher.EditTeacher(SelectedTeacherID, TeacherName, TeacherBirthday, TeacherGender, TeacherPhoneNumber, TeacherEmail, TeacherAddress, TeacherReligion, TeacherEthnicity, TeacherNationality, TeacherGroupSubject, Avatar, TeacherAcademicLevel, TeacherIdentifyNumber);

                Teacher_UC teacher_UC = new Teacher_UC();
                var teacher_UC_DT = teacher_UC.DataContext as Teacher_UC_ViewModel;
                teacher_UC_DT.LoadTeacherList();

                p.Close();
            });
            #endregion
        }

        public void LoadCombobox()
        {
            GROUPSUBJECTLIST = new ObservableCollection<BO_MON>(DataProvider.Ins.DB.BO_MON);
            GroupSubjectListCbb = new ObservableCollection<string>();

            foreach(var item in GROUPSUBJECTLIST)
            {
                GroupSubjectListCbb.Add(item.TEN_BO_MON);
            }    
            ACADEMICLEVELLIST =  new ObservableCollection<TRINH_DO_HOC_VAN>(DataProvider.Ins.DB.TRINH_DO_HOC_VAN);
            AcademicLevelListCbb = new ObservableCollection<string>();
            foreach (var item in ACADEMICLEVELLIST)
            {
                AcademicLevelListCbb.Add(item.TEN_TDHV);
            }
            LoadNationalityListToCombobox();
            LoadEthnicityListToCombobox();
            LoadReligionListToCombobox();
        }

        public void ResetTextBox()
        {
            TeacherName = "";
            TeacherGender = "";
            TeacherBirthday = null;
            TeacherEmail = "";
            TeacherGroupSubject = "";
            TeacherAddress = "";
            TeacherEthnicity = "";
            TeacherReligion = "";
            TeacherPhoneNumber = "";
            TeacherAcademicLevel = "";
            TeacherNationality = "";
            TeacherIdentifyNumber = "";
            Avatar = null;
            AvatarSource = null;
        }
        public void LoadSelectedTeacher(int id_teacher)
        {
            SelectedTeacherID = id_teacher;
            TEACHER selected_TEACHER = new TEACHER();
            selected_TEACHER.giaovien = DataProvider.Ins.DB.GIAO_VIEN.Where(x => x.MA_GIAO_VIEN == id_teacher).SingleOrDefault();
            TeacherName = selected_TEACHER.giaovien.HO_TEN;
            TeacherGender = selected_TEACHER.giaovien.GIOI_TINH;
            TeacherBirthday = selected_TEACHER.giaovien.NGAY_SINH;
            TeacherEmail = selected_TEACHER.giaovien.EMAIL;
            TeacherGroupSubject = selected_TEACHER.giaovien.BO_MON.TEN_BO_MON;
            TeacherAddress = selected_TEACHER.giaovien.DIA_CHI;
            TeacherEthnicity = selected_TEACHER.giaovien.DAN_TOC.TEN_DAN_TOC;
            TeacherReligion = selected_TEACHER.giaovien.TON_GIAO.TEN_TON_GIAO;
            TeacherPhoneNumber = selected_TEACHER.giaovien.SO_DIEN_THOAI;
            TeacherAcademicLevel = selected_TEACHER.giaovien.TRINH_DO_HOC_VAN.TEN_TDHV;
            TeacherNationality = selected_TEACHER.giaovien.QUOC_TICH.TEN_QUOC_TICH;
            TeacherIdentifyNumber = selected_TEACHER.giaovien.SO_CMND;
            Avatar = selected_TEACHER.giaovien.AVATAR;

            if (string.IsNullOrEmpty(Avatar))
            {
                AvatarSource = null;
            }
            else
            {
                AvatarSource = ImageProvider.GetImage(Avatar);
            }
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
    }
}
>>>>>>> origin/student
