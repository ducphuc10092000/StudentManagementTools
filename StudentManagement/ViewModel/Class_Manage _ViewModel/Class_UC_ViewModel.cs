using StudentManagement.Model;
using StudentManagement.Model.CLASS;
using StudentManagement.View.Class_Manage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagement.ViewModel.Class_Manage__ViewModel
{
    public class Class_UC_ViewModel : BaseViewModel
    {
        #region Declare command
        public ICommand Open_AddNewClass_WD_Command { get; set; }
        public ICommand Open_EditClass_WD_Command { get; set; }
        #endregion

        #region Binding CLASS_UC
        private ObservableCollection<LOP> _CLASSLIST;
        public ObservableCollection<LOP> CLASSLIST { get => _CLASSLIST; set { _CLASSLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<CLASS> _CLASSLISTDTG;
        public ObservableCollection<CLASS> CLASSLISTDTG { get => _CLASSLISTDTG; set { _CLASSLISTDTG = value; OnPropertyChanged(); } }


        private ObservableCollection<NAM_HOC> _SCHOOLYEARLIST;
        public ObservableCollection<NAM_HOC> SCHOOLYEARLIST { get => _SCHOOLYEARLIST; set { _SCHOOLYEARLIST = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _SchoolYearListCbb;
        public ObservableCollection<string> SchoolYearListCbb { get => _SchoolYearListCbb; set { _SchoolYearListCbb = value; OnPropertyChanged(); } }

        private CLASS _selectedClass;
        public CLASS selectedClass { get => _selectedClass; set { _selectedClass = value; OnPropertyChanged(); } }
        #endregion

        public Class_UC_ViewModel()
        {
            LoadCombobox();
            LoadClassList();
            Open_AddNewClass_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                AddNewClass_WD addNewClass_WD = new AddNewClass_WD();
                var addNewClass_WD_DT = addNewClass_WD.DataContext as AddNewClass_WD_ViewModel;
                addNewClass_WD_DT.ResetTextbox();
                addNewClass_WD.ShowDialog();
                addNewClass_WD.Close();
            });

            Open_EditClass_WD_Command = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                EditClass_WD editClass_WD = new EditClass_WD();
                var editClass_WD_DT = editClass_WD.DataContext as AddNewClass_WD_ViewModel;
                editClass_WD_DT.selectedClass = selectedClass;
                editClass_WD_DT.LoadCombobox();
                editClass_WD_DT.LoadSelectedClass();
                editClass_WD.ShowDialog();
                editClass_WD.Close();
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
        }
        
        public void LoadClassList()
        {
            CLASSLIST = new ObservableCollection<LOP>(DataProvider.Ins.DB.LOPs);
            CLASSLISTDTG = new ObservableCollection<CLASS>();
            foreach(var item in CLASSLIST)
            {
                CLASS temp = new CLASS();
                temp.lop = item;
                temp.si_so = item.SI_SO.ToString() + "/" + item.SI_SO_TOI_DA.ToString();
                CLASSLISTDTG.Add(temp);
            }    
        }    
    }
}
