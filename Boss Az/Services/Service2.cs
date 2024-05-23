using System.Windows.Controls;

namespace Boss_Az.Services;

public class Service2
{
    public static void ChangePageService<TView, TViewModel>(object? obj)
      where TView : Page where TViewModel : Service
    {
        Page? page = obj as Page;
        if (page is not null)
        {
            TView? singIUpPageView = App.Container?.GetInstance<TView>();
            singIUpPageView!.DataContext = App.Container?.GetInstance<TViewModel>();

            page.NavigationService.Navigate(singIUpPageView);
        }
    }
}
