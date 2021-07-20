using Microsoft.Extensions.DependencyInjection;

using CompletedMVVMTestBM.ViewModels;

using System.Windows;

namespace CompletedMVVMTestBM.Views
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
