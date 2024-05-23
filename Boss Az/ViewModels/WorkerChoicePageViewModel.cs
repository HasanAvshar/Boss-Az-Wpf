using Boss_Az.Services;
using Boss_Az.Views.Employee.Pages;
using Boss_Az.Views.Worker.Pages;
using Command.Commands;
using System.Windows.Controls;
using System.Windows.Input;

namespace Boss_Az.ViewModels;

public class WorkerChoicePageViewModel:Service
{
    private bool controlsEnabled = true;
    public bool ControlsEnabled
    {
        get { return controlsEnabled; }
        set { controlsEnabled = value; OnPropertyChanged(); }
    }

    public ICommand WorkerSingInCommand { get; set; }
    public ICommand WorkerSingUpCommand { get; set; }

    public WorkerChoicePageViewModel()
    {
        WorkerSingInCommand = new RelayCommand(WorkerSingInExecute);
        WorkerSingUpCommand = new RelayCommand(WorkerSingUpExecute);
    }

    private void WorkerSingInExecute(object? obj)
    {
        Page? page = obj as Page;
        if (page is not null)
        {
            Sign_In_PageView singInPageView = new Sign_In_PageView();
            page.NavigationService.Navigate(singInPageView);
        }
    }

    private void WorkerSingUpExecute(object? obj)
    {
        Page? page = obj as Page;
        if (page is not null)
        {
            Sign_Up_PageView singUpPageView = new Sign_Up_PageView();
            page.NavigationService.Navigate(singUpPageView);
        }
    }
}
