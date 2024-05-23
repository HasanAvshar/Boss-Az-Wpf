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
    public class SearchPageViewModel : Service
    {
        private ObservableCollection<Vacansia> vacancies = new ObservableCollection<Vacansia>();
        public ObservableCollection<Vacansia> Vacancies
        {
            get => vacancies;
            set { vacancies = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public ICommand FillEmployeesCommand { get; }

        public SearchPageViewModel()
        {
            vacancies = DataBase.Vacancies;
            FillEmployeesCommand = new RelayCommand(param => LoadEmployees());
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
