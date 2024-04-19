using generator.ViewModels.Helpers;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace generator.ViewModels
{
    internal class TestViewModel : BindingHelper
    {
        private readonly bool _isActiveEditButton;

        public TestViewModel(bool isActiveEditButton)
        {
            _isActiveEditButton = isActiveEditButton;
            ReturnCommand = new BindableCommand(ReturnCommandExecute);
            PassTestCommand = new BindableCommand(PassTestCommandExecute);
            EditTestCommand = new BindableCommand(EditTestCommandExecute, CanEditTest);
        }

        public ICommand ReturnCommand { get; }
        public ICommand PassTestCommand { get; }
        public ICommand EditTestCommand { get; }

        private object _currentPage;

        public object CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        private void LoadPage()
        {
            CurrentPage = File.Exists("test.json") ? new PassTestPage() : new NoTestPage();
        }

        private void ReturnCommandExecute(object obj)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Application.Current.MainWindow.Close();
        }

        private void PassTestCommandExecute(object obj)
        {
            LoadPage();
        }

        private bool CanEditTest(object obj)
        {
            return _isActiveEditButton;
        }

        private void EditTestCommandExecute(object obj)
        {
            CurrentPage = new EditTestPage();
        }
    }
}
