using Boss_Az.ViewModels;
using System.Windows.Input;
using System.Windows.Navigation;
using static System.Net.Mime.MediaTypeNames;

namespace Boss_Az.Views.Window;

public partial class MainWindowView : NavigationWindow
{
    public MainWindowView()
    {
        InitializeComponent();
        DataContext= new MainWindowViewModel();
    }

}
