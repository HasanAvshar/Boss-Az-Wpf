using Boss_Az.DataBases;
using Boss_Az.Models;
using Boss_Az.Services;
using Boss_Az.Users;
using Command.Commands;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Boss_Az.ViewModels
{
    public class NotificationPageViewModel : Service
    {
        private ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set { employees = value; OnPropertyChanged(); }
        }

        public ICommand FillEmployeesCommand { get; }
        public NotificationPageViewModel()
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            Employees.Clear();
            DataBase.LoadFile();
            foreach (var employee in DataBase.Employees)
            {
                Employees.Add(employee);
            }
        }
    }
}
