using System.Collections.ObjectModel;
using System.Windows.Input;
using Boss_Az.DataBases;
using Boss_Az.Models;
using Boss_Az.Services;
using Command.Commands;

namespace Boss_Az.ViewModels
{
    public class DeleteVacancyPageViewModel : Service
    {
        public ObservableCollection<Vacansia> Vacancies { get; set; }
        public Vacansia SelectedVacancy { get; set; }

        public ICommand DeleteVacancyCommand { get; }

        public DeleteVacancyPageViewModel()
        {
            Vacancies = DataBase.Vacancies;
            DeleteVacancyCommand = new RelayCommand(DeleteVacancy, CanDeleteVacancy);
        }

        private void DeleteVacancy(object parameter)
        {
            if (SelectedVacancy != null)
            {
                Vacancies.Remove(SelectedVacancy);
                DataBase.VacansiaSaveChanges();
            }
        }

        private bool CanDeleteVacancy(object parameter)
        {
            return SelectedVacancy != null;
        }
    }
}
