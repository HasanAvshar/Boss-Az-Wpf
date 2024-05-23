using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Boss_Az.Services;
using Boss_Az.Users;
using Boss_Az.Views;
using Boss_Az.Views.Worker.Pages;
using Command.Commands;

namespace Boss_Az.ViewModels
{
    public class MenuPageViewModel : Service
    {
        public RelayCommand VacanciesCommand { get; set; }
        public RelayCommand SearchCommand { get; set; }
        public RelayCommand AboutCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }
        public VacanciesPageViewModel VacancyVM { get; set; }
        public SearchPageViewModel SearchVM { get; set; }
        public AboutPageViewModel AboutVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public MenuPageViewModel()
        {
            VacancyVM = new VacanciesPageViewModel();
            SearchVM = new SearchPageViewModel();
            AboutVM = new AboutPageViewModel();
            CurrentView = new VacanciesPageView();
            VacanciesCommand = new RelayCommand(o => CurrentView = new VacanciesPageView());
            SearchCommand = new RelayCommand(o => CurrentView = new SearchPageView());
            AboutCommand = new RelayCommand(o => CurrentView = new AboutPageView());
            ExitCommand = new RelayCommand(o => ExitApplication());
        }
        private Employee? currentEmployee;
        public Employee? CurrentEmployee
        {
            get => currentEmployee;
            set { currentEmployee = value; OnPropertyChanged(); }
        }
       
        private void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
}
