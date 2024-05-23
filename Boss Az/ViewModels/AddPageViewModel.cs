using Boss_Az.DataBases;
using Boss_Az.Models;
using Boss_Az.Services;
using Boss_Az.Users;
using Boss_Az.Views.Worker.Pages;
using Command.Commands;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows;

public class AddPageViewModel : Service
{
    public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    private ObservableCollection<Vacansia> vacancies = new ObservableCollection<Vacansia>();
    public ObservableCollection<Vacansia> Vacancies
    {
        get => vacancies;
        set { vacancies = value; OnPropertyChanged(); }
    }

    public ICommand FillEmployeesCommand { get; }
    public ICommand AddButtonCommand { get; }

    public AddPageViewModel()
    {
        vacancies = DataBase.Vacancies; 
        FillEmployeesCommand = new RelayCommand(param => FillEmployees());
        AddButtonCommand = new RelayCommand(change => GoAddVacansiaPage(change));
    }

    public void FillEmployees()
    {
        if (DataBase.Employees.Count > 0)
        {
            var lastEmployee = DataBase.Employees.Last();
            Employees.Add(lastEmployee);
        }
    }

   

    private void GoAddVacansiaPage(object change)
    {
        if (change is UserControl page)
        {
            var navigationService = NavigationService.GetNavigationService(page);
            if (navigationService != null)
            {
                navigationService.Navigate(new AddVacansiaPageView());
            }
            else
            {
                MessageBox.Show("NavigationService is null. Ensure the UserControl is inside a Frame that supports navigation.", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        else
        {
            MessageBox.Show("Command parameter is not a UserControl.", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

}
