using Boss_Az.DataBases;
using Boss_Az.Models;
using Boss_Az.Services;
using Boss_Az.Users;
using Command.Commands;
using System.Windows.Controls;
using System.Windows.Input;

namespace Boss_Az.ViewModels;

public class WorkerSignUpPageViewModel:Service
{
    public WorkerSignUpPageViewModel()
    {
        NewWorker = new Worker();
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
    private Worker newWorker;
    public Worker NewWorker { get => newWorker; set { newWorker = value; OnPropertyChanged(); } }
    public ICommand SingUpCommand { get; set; }

    public bool CanSingUpCommandExecute(object? obj)
    {
        if (!string.IsNullOrEmpty(NewWorker.Email) &&
            !string.IsNullOrEmpty(NewWorker.Name) &&
            !string.IsNullOrEmpty(NewWorker.Surname) && !string.IsNullOrEmpty(NewWorker.Password))
            return true;
        return false;
    }
    public void SingUpCommandExecute(object? obj)
    {
        DataBase.Workers.Add(NewWorker);
        NewWorker = new Worker();
        DataBase.WorkerSaveChanges();
    }
    #endregion
}
