using Dark.Net;
using fourCities.Handlers;
using System.Windows;

namespace fourCities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AppStartupHandler.StartupChecks();
            InitializeComponent();
            DarkNet.Instance.SetWindowThemeWpf(this, Theme.Dark);
        }
    }
}