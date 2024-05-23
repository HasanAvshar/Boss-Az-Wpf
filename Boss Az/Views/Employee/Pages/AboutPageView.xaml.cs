using Boss_Az.ViewModels;
using System.Windows.Controls;
namespace Boss_Az.Views;

public partial class AboutPageView : UserControl
{
    public AboutPageView()
    {
        InitializeComponent();
        DataContext=new AboutPageViewModel();
    }
}
