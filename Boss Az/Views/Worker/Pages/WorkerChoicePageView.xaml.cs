using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views.Worker;

public partial class WorkerChoicePageView : Page
{
    public WorkerChoicePageView()
    {
        InitializeComponent();
        DataContext = new WorkerChoicePageViewModel();
    }
}
