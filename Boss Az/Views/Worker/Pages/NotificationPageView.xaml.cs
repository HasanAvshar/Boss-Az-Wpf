using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views.Worker.Pages;

public partial class NotificationPageView: UserControl
{
    public NotificationPageView()
    {
        InitializeComponent();
        DataContext = new NotificationPageViewModel();
    }
}
