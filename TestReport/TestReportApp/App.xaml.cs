using System.Windows;
using TestReportApp.View;
using TestReportApp.ViewModel;

namespace TestReportApp
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
