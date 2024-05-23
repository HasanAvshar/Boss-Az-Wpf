using System.Windows.Controls;
using System.Windows.Input;
using Boss_Az.Services;
using Boss_Az.Users;
using Boss_Az.Views;
using Command.Commands;

namespace Boss_Az.ViewModels
{
    public class VacanciesPageViewModel : Service
    {
        private Employee? currentEmployee;

        public Employee? CurrentEmployee { get => currentEmployee; set { currentEmployee = value; OnPropertyChanged(); } }

    }
}
