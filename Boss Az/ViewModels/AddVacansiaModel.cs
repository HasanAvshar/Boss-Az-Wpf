using Boss_Az.DataBases;
using Boss_Az.Models;
using Boss_Az.Services;
using Command.Commands;
using System.Windows.Controls;
using System.Windows.Input;

namespace Boss_Az.ViewModels;

public class AddVacansiaModel:Service
{

    public AddVacansiaModel()
    {
        NewVacancia = new Vacansia();
        BackCommand = new RelayCommand(BackCommandExecute);
        SaveVacancyCommand = new RelayCommand(SaveVacanciesCommandExecute, CanSaveVacanciaExecute);
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

    private Vacansia? newVacancia;
    public Vacansia? NewVacancia { get => newVacancia; set { newVacancia = value; OnPropertyChanged(); } }

    #region SaveCommandSection
    public ICommand SaveVacancyCommand { get; set; }
    public bool CanSaveVacanciaExecute(object? obj)
    {
        return NewVacancia != null &&
               !string.IsNullOrEmpty(NewVacancia.Text) &&
               NewVacancia.Text.Length >= 3 &&
               !string.IsNullOrEmpty(NewVacancia.Salary) &&
               NewVacancia.Salary.Length >= 3 &&
               !string.IsNullOrEmpty(NewVacancia.JobTitle) &&
               NewVacancia.JobTitle.Length >= 3 &&
               NewVacancia.Date != null;
    }


    public void SaveVacanciesCommandExecute(object? obj)
    {
        DataBase.Vacancies.Add(NewVacancia!);
        DataBase.VacansiaSaveChanges();
        NewVacancia = new Vacansia();
    }
    #endregion
}
