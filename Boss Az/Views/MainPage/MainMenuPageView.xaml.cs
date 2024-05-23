using Boss_Az.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace Boss_Az.Views.MainPage;

public partial class MainMenuPageView : Page
{
    public MainMenuPageView()
    {
        InitializeComponent();
        DataContext = new MainMenuPageViewModel();
    }
   
}
