using System.Windows;
using AjusteProlex_WPF.Download;

namespace AjusteProlex_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await DownloadParameters.ApplicationListAsync();
        }
    }
}
