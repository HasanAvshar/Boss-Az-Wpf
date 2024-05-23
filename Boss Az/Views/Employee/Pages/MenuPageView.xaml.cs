using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views;

public partial class MenuPageView : Page
{
    public MenuPageView()
    {
        InitializeComponent();
        DataContext=new MenuPageViewModel();
    }

   
}
