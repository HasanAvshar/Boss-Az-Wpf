using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views.Worker.Pages
{
    public partial class Sign_In_PageView : Page
    {
        public Sign_In_PageView()
        {
            InitializeComponent();
            DataContext=new WorkerSignInPageViewModel();
        }
    }
}
