using Boss_Az.Models;
using Boss_Az.Users;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace Boss_Az.DataBases;

public static class DataBase
{
    public static ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    public static ObservableCollection<Worker> Workers { get; set; } = new ObservableCollection<Worker>();
    public static ObservableCollection<Vacansia> Vacancies { get; set; } = new ObservableCollection<Vacansia>();
    public static string FolderName { get; set; } = "DataBases";

    static DataBase()
    {
        Workers.Add(new Worker("Cavid", "Atamoghlanov", "cavid@gmail.com", "cavid123"));
    }

    public static void EmployeeSaveChanges()
    {
        if (!Directory.Exists(FolderName))
            Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Employees.json";
        if (!File.Exists(fileName))
            File.Create(fileName).Close();

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(Employees, options);
        File.WriteAllText(fileName, json);
    }

    public static void LoadFromFile()
    {
        if (!Directory.Exists(FolderName))
            Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Employees.json";
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            var aa = JsonSerializer.Deserialize<ObservableCollection<Employee>>(json)!;
            foreach (var item in aa)
                Employees.Add(item);
        }
    }

    public static void WorkerSaveChanges()
    {
        if (!Directory.Exists(FolderName))
            Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Workers.json";
        if (!File.Exists(fileName))
            File.Create(fileName).Close();

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(Workers, options);
        File.WriteAllText(fileName, json);
    }

    public static void LoadFile()
    {
        if (!Directory.Exists(FolderName))
            Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Workers.json";
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            var aa = JsonSerializer.Deserialize<ObservableCollection<Worker>>(json)!;
            foreach (var item in aa)
                Workers.Add(item);
        }
    }

    public static void VacansiaSaveChanges()
    {
        if (!Directory.Exists(FolderName))
            Directory.CreateDirectory(FolderName);

        string fileName = FolderName + "/Vacancies.json";
        if (!File.Exists(fileName))
            File.Create(fileName).Close();

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(Vacancies, options);
        File.WriteAllText(fileName, json);
    }

    public static void LoadFileVacancy()
    {
        if (!Directory.Exists(FolderName))
            Directory.CreateDirectory(FolderName);
        string fileName = FolderName + "/Vacancies.json";
        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            var js = JsonSerializer.Deserialize<ObservableCollection<Vacansia>>(json)!;
            foreach (var item in js)
                Vacancies.Add(item);
        }
    }
}
