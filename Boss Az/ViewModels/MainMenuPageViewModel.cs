using Boss_Az.Services;
using Boss_Az.Views.Employee.Pages;
using Boss_Az.Views.Worker;
using Command.Commands;
using System.Windows.Controls;
using System.Windows.Input;

namespace Boss_Az.ViewModels;

public class MainMenuPageViewModel: Service
{
    public MainMenuPageViewModel()
    {
        EmployeeCommand = new RelayCommand(EmployeeCommandExecute);
        WorkerCommand = new RelayCommand(WorkerCommandExecute);
    }

    #region EmployeePage
    public ICommand EmployeeCommand { get; set; }

    private void EmployeeCommandExecute(object? obj)
    {
        Page? page = obj as Page;
        if (page is not null)
        {
            EmployeeChoicePageView choice = new EmployeeChoicePageView();
            choice.DataContext = new EmployeeChoicePageViewModel();

            page.NavigationService.Navigate(choice);
        }
    }
    #endregion

    #region WorkerPage
    public ICommand WorkerCommand { get; set; }

    private void WorkerCommandExecute(object? obj)
    {
        Page? page = obj as Page;
        if (page is not null)
        {
            WorkerChoicePageView choice1 = new WorkerChoicePageView();
            choice1.DataContext = new WorkerChoicePageViewModel();

            page.NavigationService.Navigate(choice1);
        }
    }
    #endregion
}