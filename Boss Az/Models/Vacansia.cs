using Boss_Az.Services;
using System.Windows.Input;
namespace Boss_Az.Models;

public class Vacansia:Service
{
    private string? text;
    private string? salary;
    private string? job_title;
    private DateTime date = DateTime.Now;

    public string? Text { get => text; set { text = value; OnPropertyChanged(); } }
    public string? Salary { get => salary; set { salary = value; OnPropertyChanged(); } }
    public string? JobTitle { get => job_title; set { job_title = value; OnPropertyChanged(); } }
    public DateTime Date { get => date; set { date = value; OnPropertyChanged(); } }

    public void SetValue(Vacansia? vacancy)
    {
        this.Text = vacancy?.Text;
        this.Salary = vacancy?.Salary;
        this.JobTitle = vacancy?.JobTitle;
        this.Date = vacancy?.Date ?? DateTime.Now;
    }
    public ICommand FillEmployeesCommand { get; }

    public object Clone()
    {
        return new Vacansia
        {
            Text = this.Text,
            Salary= this.Salary,
            JobTitle = this.JobTitle,
            Date = this.Date
        };
    }
    public bool Equals(Vacansia? other)
    {
        if (other is null)
            return false;

        return this.Text == other.Text && this.Salary == other.Salary && this.JobTitle == other.JobTitle && this.Date == other.Date;
    }
}
