using Boss_Az.ViewModels;
using System.Windows.Controls;

namespace Boss_Az.Views.Employee.Pages
{
    public partial class SingUpPageView : Page
    {
        public SingUpPageView()
        {
            InitializeComponent();
            DataContext = new EmployeeSingUpPageViewModel();
        }
    }
}
