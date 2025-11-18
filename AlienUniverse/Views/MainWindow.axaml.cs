using AlienUniverse.ViewModels;
using Avalonia.Controls;

namespace AlienUniverse.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}