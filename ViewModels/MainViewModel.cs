using System.Windows.Input;
using System.Windows;
using generator.ViewModels.Helpers;

namespace generator.ViewModels
{
    internal class MainViewModel : BindingHelper
    {
        private const string _password = "кодовое слово";
        private string _enteredPassword;
        
        public string Password
        {
            get => _enteredPassword;
            set
            {
                _enteredPassword = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand PassCommand { get; }
        public ICommand RedactorCommand { get; }

        public MainViewModel() 
        {
            PassCommand = new BindableCommand(PassCommandExecute);
            RedactorCommand = new BindableCommand(RedactorCommandExecute);
        }

        private void PassCommandExecute(object obj)
        {
            OpenTestWindow(false);
        }

        private void RedactorCommandExecute(object obj)
        {
            
            if (_enteredPassword?.ToLower() == _password)
            {
                OpenTestWindow(true);
                Password = string.Empty;
            }
        }

        private void OpenTestWindow(bool isActiveEditButton)
        {
            TestWindow testWindow = new TestWindow(isActiveEditButton);
            testWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
