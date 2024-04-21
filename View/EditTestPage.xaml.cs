using generator.ViewModels;
using System.Windows.Controls;

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
