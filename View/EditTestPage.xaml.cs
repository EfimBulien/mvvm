using generator.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace generator
{
    public partial class EditTestPage : Page
    {
        public EditTestPage()
        {
            InitializeComponent();
            DataContext = new EditTestViewModel();
        }
    }
}
