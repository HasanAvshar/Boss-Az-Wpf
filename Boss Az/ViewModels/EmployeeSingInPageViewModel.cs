using Boss_Az.Services;
using Command.Commands;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using Boss_Az.DataBases;
using Boss_Az.Views;
using System.Windows;

namespace Boss_Az.ViewModels;

public class EmployeeSingInPageViewModel: Service
{
    private string? errorMassage;
    public string? ErrorMassage { get => errorMassage; set { errorMassage = value; OnPropertyChanged(); } }
    public EmployeeSingInPageViewModel()
    {
        BackCommand = new RelayCommand(BackCommandExecute);
        LoginCommand = new RelayCommand(LoginCommandExecute);
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

    #region LoginCommandSection
    private string? email;
    private string? password;


    public string? Email { get => email; set { email = value; OnPropertyChanged(); } }
    public string? Password { get => password; set { password = value; OnPropertyChanged(); } }
    public ICommand LoginCommand { get; set; }

    public void LoginCommandExecute(object? obj)
    {
        var isLogin = DataBase.Employees.Any(a => a.Email == Email);
        if (isLogin)
        {
            var isPassword = DataBase.Employees.FirstOrDefault(a => a.Email == Email).Password == Password;
            if (isPassword)
            {
                var employee = DataBase.Employees.FirstOrDefault(a => a.Email == Email);

                Page? page = obj as Page;
                MenuPageView menuView = App.Container?.GetInstance<MenuPageView>()!;

                var menuViewModel = App.Container?.GetInstance<MenuPageViewModel>()!;
                menuViewModel.CurrentEmployee = employee;

                menuView.DataContext = menuViewModel;

                page.NavigationService.Navigate(menuView);
            }
            ErrorMassage = "Password is incorrect";
            return;
        }
        ErrorMassage = "Email is incorrect";

    }
    #endregion
    public ICommand GoogleCommand { get; }
    public ICommand FacebookCommand { get; }
    public ICommand LinkedinCommand { get; }

    private void OpenUrl(string url)
    {
        try
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("URL açılamadı: " + ex.Message);
        }
    }

    private void GoogleClick(object obj)
    {
        OpenUrl("https://accounts.google.com/v3/signin/identifier?authuser=0&continue=https%3A%2F%2Fwww.google.az%2F&ec=GAlAmgQ&hl=az&flowName=GlifWebSignIn&flowEntry=AddSession&dsh=S620904089%3A1715433239416345&ddm=0");
    }
    private void FacebookClick(object obj)
    {
        OpenUrl("https://en-gb.facebook.com/");
    }
    private void LinkedinClick(object obj)
    {
        OpenUrl("https://www.linkedin.com/login");
    }
}
