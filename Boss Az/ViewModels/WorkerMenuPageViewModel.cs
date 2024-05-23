using Boss_Az.Models;
using Boss_Az.Services;
using Boss_Az.Views;
using Boss_Az.Views.Worker.Pages;
using Command.Commands;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace Boss_Az.ViewModels
{
    public class WorkerMenuPageViewModel : Service
    {
        public RelayCommand VacanciesCommand { get; set; }
        public RelayCommand AboutCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }
        public RelayCommand NotifyCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public VacanciesPageViewModel VacancyVM { get; set; }
        public AddPageViewModel AddVM { get; set; }
        public AboutPageViewModel AboutVM { get; set; }
        public NotificationPageViewModel NotifyVM { get; set; }
        public DeleteVacancyPageViewModel DeleteVM { get; set; }
        private object _workerView;
        public object WorkerView
        {
            get { return _workerView; }
            set { _workerView = value; OnPropertyChanged(); }
        }

        public WorkerMenuPageViewModel()
        {
            VacancyVM = new VacanciesPageViewModel();
            AddVM = new AddPageViewModel();
            DeleteVM = new DeleteVacancyPageViewModel();
            AboutVM = new AboutPageViewModel();
            NotifyVM = new NotificationPageViewModel();
            WorkerView = new VacanciesPageView();
            VacanciesCommand = new RelayCommand(o => WorkerView = new VacanciesPageView());
            DeleteCommand = new RelayCommand(o => WorkerView = new DeleteVacancyPageView());
            AddCommand = new RelayCommand(o => WorkerView = new AddPageView());
            NotifyCommand = new RelayCommand(o => WorkerView = new NotificationPageView());
            AboutCommand = new RelayCommand(o => WorkerView = new AboutPageView());
            ExitCommand = new RelayCommand(o => ExitApplication());
        }

        private Worker? currentWorker;
        public Worker? CurrentWorker
        {
            get => currentWorker;
            set { currentWorker = value; OnPropertyChanged(); }
        }

        private void ExitApplication()
        {
            Application.Current.Shutdown();
        }
    }
}
