using System.Windows;


namespace WpfApplicationData;


public partial class MainWindow : Window
{
    public MainWindow(MainWindow viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}