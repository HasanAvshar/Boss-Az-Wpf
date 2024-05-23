using System.Windows.Input;
using Command.Commands;
using Boss_Az.Users;
using Boss_Az.DataBases;
using Boss_Az.Services;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace Boss_Az.ViewModels
{
    public class EmployeeSingUpPageViewModel : Service
    {
        public EmployeeSingUpPageViewModel()
        {
            NewEmployee = new Employee();
            BackCommand = new RelayCommand(BackCommandExecute);
            SingUpCommand = new RelayCommand(SingUpCommandExecute, CanSingUpCommandExecute);

        }

        #region BackCommandSection
        public ICommand BackCommand { get; set; }
        public void BackCommandExecute(object? obj)
        {
            Page? page = obj as Page;
            if (page is not null && page.NavigationService.CanGoBack)
                page.NavigationService.GoBack();
        }
        #endregion
        #region SingUpCommandSection
        private Employee newEmployee;
        public Employee NewEmployee { get => newEmployee; set { newEmployee = value; OnPropertyChanged(); } }
        public ICommand SingUpCommand { get; set; }

        public bool CanSingUpCommandExecute(object? obj)
        {
            if (!string.IsNullOrEmpty(NewEmployee.Email) &&
                !string.IsNullOrEmpty(NewEmployee.Name) &&
                !string.IsNullOrEmpty(NewEmployee.Surname) && !string.IsNullOrEmpty(NewEmployee.Password))
                return true;
            return false;
        }
        public void SingUpCommandExecute(object? obj)
        {
            DataBase.Employees.Add(NewEmployee);
            NewEmployee = new Employee();
            DataBase.EmployeeSaveChanges(); 
        }
        #endregion

    }
}
