using Boss_Az.ViewModels;
using System.Windows.Controls;
namespace Boss_Az.Views.Worker.Pages;

public partial class Sign_Up_PageView : Page
{
    public Sign_Up_PageView()
    {
        InitializeComponent();
        DataContext = new WorkerSignUpPageViewModel();
    }
}
