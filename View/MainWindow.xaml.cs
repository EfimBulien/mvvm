using generator.ViewModels;

namespace generator;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}