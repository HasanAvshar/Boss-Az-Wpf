using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views.Worker.Pages;

public partial class DeleteVacancyPageView : UserControl
{
    public DeleteVacancyPageView()
    {
        InitializeComponent();
        DataContext = new DeleteVacancyPageViewModel();
    }
}
