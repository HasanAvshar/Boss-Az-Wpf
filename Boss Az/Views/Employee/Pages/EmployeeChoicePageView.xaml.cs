using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views.Employee.Pages;

public partial class EmployeeChoicePageView : Page
{
    public EmployeeChoicePageView()
    {
        InitializeComponent();
        DataContext = new EmployeeChoicePageViewModel();
    }
}
