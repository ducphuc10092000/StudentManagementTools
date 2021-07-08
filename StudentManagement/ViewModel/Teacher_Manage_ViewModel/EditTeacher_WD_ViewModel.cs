using Microsoft.Win32;
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
    class EditTeacher_WD_ViewModel : BaseViewModel
    {
        #region Binding COMBOBOX
        private ObservableCollection<BO_MON> _SUBJECTLIST;
        public ObservableCollection<BO_MON> SUBJECTLIST { get => _SUBJECTLIST; set { _SUBJECTLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _SubjectList;
        public ObservableCollection<string> SubjectList { get => _SubjectList; set { _SubjectList = value; OnPropertyChanged(); } }

        #endregion
        #region Bingding TEXT EDIT_Teacher_WD
        private int _SelectedTeacherID;
        public int SelectedTeacherID { get => _SelectedTeacherID; set { _SelectedTeacherID = value; OnPropertyChanged(); } }

        private string _TeacherName;
        public string TeacherName { get => _TeacherName; set { _TeacherName = value; OnPropertyChanged(); } }

        private string _TeacherEmail;
        public string TeacherEmail { get => _TeacherEmail; set { _TeacherEmail = value; OnPropertyChanged(); } }

        private string _TeacherPhoneNumber;
        public string TeacherPhoneNumber { get => _TeacherPhoneNumber; set { _TeacherPhoneNumber = value; OnPropertyChanged(); } }

        private string _TeacherGender;
        public string TeacherGender { get => _TeacherGender; set { _TeacherGender = value; OnPropertyChanged(); } }

        private string _TeacherBirthday;
        public string TeacherBirthday { get => _TeacherBirthday; set { _TeacherBirthday = value; OnPropertyChanged(); } }

        private string _TeacherSubject;
        public string TeacherSubject { get => _TeacherSubject; set { _TeacherSubject = value; OnPropertyChanged(); } }

        private string _TeacherEthnicity;
        public string TeacherEthnicity { get => _TeacherEthnicity; set { _TeacherEthnicity = value; OnPropertyChanged(); } }

        private string _TeacherReligion;
        public string TeacherReligion { get => _TeacherReligion; set { _TeacherReligion = value; OnPropertyChanged(); } }

        private string _TeacherAddress;
        public string TeacherAddress { get => _TeacherAddress; set { _TeacherAddress = value; OnPropertyChanged(); } }

        private ImageSource _AvatarSource;
        public ImageSource AvatarSource { get => _AvatarSource; set { _AvatarSource = value; OnPropertyChanged(); } }

        private string _Avatar;
        public string Avatar { get => _Avatar; set { _Avatar = value; OnPropertyChanged(); } }
        #endregion

        #region Command
        public ICommand QuitCommand { get; set; }
        public ICommand ConfirmEditTeacherCommand { get; set; }
        public ICommand ChangePictureCommand { get; set; }
        public ICommand DeletePictureCommand { get; set; }

        #endregion

        public EditTeacher_WD_ViewModel()
        {
            ConfirmEditTeacherCommand = new RelayCommand<Window>((p) =>
            {

                return true;
            }, (p) =>
            {
                TEACHER selected_Teacher = new TEACHER();

                //BO_MON selected_Subject = DataProvider.Ins.DB.BO_MON.Where(x => x.TEN_BO_MON == TeacherSubject);

                DAN_TOC ethnicity = DataProvider.Ins.DB.DAN_TOC.Where(x => x.TEN_DAN_TOC == TeacherEthnicity).SingleOrDefault();

                selected_Teacher.EditTeacher(SelectedTeacherID, TeacherName, TeacherEmail, TeacherSubject, TeacherGender, TeacherBirthday, TeacherEthnicity, TeacherReligion, TeacherPhoneNumber, TeacherAddress, Avatar);

                Teacher_UC teacher_UC = new Teacher_UC();
                var teacher_UC_DT = teacher_UC.DataContext as Teacher_UC_ViewModel;
                teacher_UC_DT.LoadTeacherList();

                p.Close();
            });

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

        }

        public void LoadSelectedTeacher(int id_teacher)
        {
            SelectedTeacherID = id_teacher;
            TEACHER selected_TEACHER = new TEACHER();
            selected_TEACHER.giaovien = DataProvider.Ins.DB.GIAO_VIEN.Where(x => x.MA_GIAO_VIEN == id_teacher).SingleOrDefault();
            TeacherName = selected_TEACHER.giaovien.HO_TEN;
            TeacherGender = selected_TEACHER.giaovien.GIOI_TINH;
            TeacherBirthday = selected_TEACHER.giaovien.NGAY_SINH.ToString();
            TeacherEmail = selected_TEACHER.giaovien.EMAIL;
            TeacherSubject = selected_TEACHER.giaovien.BO_MON.TEN_BO_MON;
            TeacherAddress = selected_TEACHER.giaovien.DIA_CHI;
            TeacherEthnicity = selected_TEACHER.giaovien.DAN_TOC.TEN_DAN_TOC;
            TeacherReligion = selected_TEACHER.giaovien.TON_GIAO.TEN_TON_GIAO;
            TeacherPhoneNumber = selected_TEACHER.giaovien.SO_DIEN_THOAI;

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

    }
}
