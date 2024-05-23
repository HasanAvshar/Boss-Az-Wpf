using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views.Employee.Pages;

public partial class SingInPageView : Page
{
    public SingInPageView()
    {
        InitializeComponent();
        DataContext = new EmployeeSingInPageViewModel();
    }
}
