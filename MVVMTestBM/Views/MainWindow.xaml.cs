using Microsoft.Extensions.DependencyInjection;

using MVVMTestBM.ViewModels;

using System.Windows;

namespace MVVMTestBM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = App.ServiceProvider.GetRequiredService<MainViewModel>();
        }
    }
}
