using generator.ViewModels;

namespace generator;

public partial class TestWindow
{
    public TestWindow(bool isActiveEditButton)
    {
        InitializeComponent();
        DataContext = new TestViewModel(isActiveEditButton);
    }
}