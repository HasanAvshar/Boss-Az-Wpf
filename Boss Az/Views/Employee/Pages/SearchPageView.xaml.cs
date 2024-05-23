using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views;

public partial class SearchPageView : UserControl
{
    public SearchPageView()
    {
        InitializeComponent();
        DataContext=new SearchPageViewModel();
    }
}
