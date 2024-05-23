using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views.Worker.Pages
{
    public partial class AddPageView : UserControl
    {
        public AddPageView()
        {
            InitializeComponent();
            DataContext=new AddPageViewModel();
        }
    }
}
