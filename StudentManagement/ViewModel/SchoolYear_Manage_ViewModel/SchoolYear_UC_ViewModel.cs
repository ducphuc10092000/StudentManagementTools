using StudentManagement.View.SchoolYear_Manage;
using System;
using System.Collections.Generic;
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
        #endregion
        public SchoolYear_UC_ViewModel()
        {
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
            });
        }
    }
}
