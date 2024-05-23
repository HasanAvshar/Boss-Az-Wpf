using Boss_Az.DataBases;
using Boss_Az.ViewModels;
using Boss_Az.Views;
using Boss_Az.Views.Employee.Pages;
using Boss_Az.Views.MainPage;
using Boss_Az.Views.Window;
using Boss_Az.Views.Worker;
using Boss_Az.Views.Worker.Pages;
using SimpleInjector;
using System.Windows;
namespace Boss_Az;


public partial class App : Application
{
    public static Container? Container { get; set; } = new Container();

    public void RegisterView()
    {
        Container?.RegisterSingleton<MainWindowView>();
        Container?.RegisterSingleton<MainMenuPageView>();
        Container?.RegisterSingleton<SingInPageView>();
        Container?.RegisterSingleton<SingUpPageView>();
        Container?.RegisterSingleton<Sign_In_PageView>();
        Container?.RegisterSingleton<Sign_Up_PageView>();
        Container?.RegisterSingleton<VacanciesPageView>();
        Container?.RegisterSingleton<MenuPageView>();
        Container?.RegisterSingleton<SearchPageView>();
        Container?.RegisterSingleton<AboutPageView>();
        Container?.RegisterSingleton<WorkerChoicePageView>();
        Container?.RegisterSingleton<WorkerMenuPageView>();
        Container?.RegisterSingleton<NotificationPageView>();
        Container?.RegisterSingleton<AddPageView>();
        Container?.RegisterSingleton<AddVacansiaPageView>();
        Container?.RegisterSingleton<DeleteVacancyPageView>();
    }

    public void RegisterViewModel()
    {
        Container?.RegisterSingleton<MainWindowViewModel>();
        Container?.RegisterSingleton<MainMenuPageViewModel>();
        Container?.RegisterSingleton<EmployeeSingInPageViewModel>();
        Container?.RegisterSingleton<EmployeeSingUpPageViewModel>();
        Container?.RegisterSingleton<WorkerSignInPageViewModel>();
        Container?.RegisterSingleton<WorkerSignUpPageViewModel>();
        Container?.RegisterSingleton<VacanciesPageViewModel>();
        Container?.RegisterSingleton<MenuPageViewModel>();
        Container?.RegisterSingleton<SearchPageViewModel>();
        Container?.RegisterSingleton<AboutPageViewModel>();
        Container?.RegisterSingleton<WorkerChoicePageViewModel>();
        Container?.RegisterSingleton<WorkerMenuPageViewModel>();
        Container?.RegisterSingleton<NotificationPageViewModel>();
        Container?.RegisterSingleton<AddPageViewModel>();
        Container?.RegisterSingleton<AddVacansiaModel>();
        Container?.RegisterSingleton<DeleteVacancyPageViewModel>();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        RegisterView();
        RegisterViewModel();

        MainWindowView? mainWindowView = Container?.GetInstance<MainWindowView>();
        mainWindowView!.DataContext = Container?.GetInstance<MainWindowViewModel>();

        DataBase.LoadFromFile();
        DataBase.LoadFile();
        DataBase.LoadFileVacancy();

        mainWindowView.ShowDialog();
    }
}
