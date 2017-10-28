using System.Linq;
using System.Windows;
using WpfApp.DbProvider;
using WpfApp.DbProvider.Models;
using WpfApp.View;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        #region Init

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainViewModel = new MainViewModel();
            var mainView = new MainView {DataContext = mainViewModel};
            mainView.Show();
        }

        #endregion
    }

    
}
