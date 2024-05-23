using Boss_Az.Services;
using Boss_Az.Views.Employee.Pages;
using Command.Commands;
using System.Windows.Controls;
using System.Windows.Input;

namespace Boss_Az.ViewModels;

public class EmployeeChoicePageViewModel : Service
{
    private bool controlsEnabled = true;
    public bool ControlsEnabled
    {
        get { return controlsEnabled; }
        set { controlsEnabled = value; OnPropertyChanged(); }
    }

    public ICommand EmployeeSingInCommand { get; set; }
    public ICommand EmployeeSingUpCommand { get; set; }

    public EmployeeChoicePageViewModel()
    {
        EmployeeSingInCommand = new RelayCommand(EmployeeSingInExecute);
        EmployeeSingUpCommand = new RelayCommand(EmployeeSingUpExecute);
    }

    private void EmployeeSingInExecute(object? obj)
    {
        Page? page = obj as Page;
        if (page is not null)
        {
            SingInPageView singInPageView = new SingInPageView();
            page.NavigationService.Navigate(singInPageView);
        }
    }

    private void EmployeeSingUpExecute(object? obj)
    {
        Page? page = obj as Page;
        if (page is not null)
        {
            SingUpPageView singUpPageView = new SingUpPageView();
            page.NavigationService.Navigate(singUpPageView);
        }
    }
}
