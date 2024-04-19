using generator.ViewModels;
using System.Windows.Controls;

namespace generator;

public partial class NoTestPage : Page
{
    public NoTestPage()
    {
        InitializeComponent();
        DataContext = new NoTestViewModel();
    }
}