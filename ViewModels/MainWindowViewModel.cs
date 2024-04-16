using System.ComponentModel;
using System.Windows.Input;

namespace generator.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private const string Password = "кодовое слово";

        private bool _isPasswordVisible;
        public bool IsPasswordVisible
        {
            get { return _isPasswordVisible; }
            set
            {
                _isPasswordVisible = value;
                OnPropertyChanged(nameof(IsPasswordVisible));
            }
        }

        public ICommand RedactorCommand { get; }
        public ICommand PassCommand { get; }
        public ICommand PasswordEnterCommand { get; }

        public MainWindowViewModel()
        {
            RedactorCommand = new RelayCommand(ExecuteRedactorCommand);
            PassCommand = new RelayCommand(ExecutePassCommand);
            PasswordEnterCommand = new RelayCommand(ExecutePasswordEnterCommand);
            IsPasswordVisible = false;
        }

        private void ExecuteRedactorCommand(object parameter)
        {
            IsPasswordVisible = true;
        }

        private void ExecutePassCommand(object parameter)
        {
            OpenTestWindow(false);
        }

        private void ExecutePasswordEnterCommand(object parameter)
        {
            var password = parameter as string;
            if (password?.ToLower() == Password)
            {
                OpenTestWindow(true);
            }
        }

        private void OpenTestWindow(bool isActiveEditButton)
        {
            var testWindow = new TestWindow(isActiveEditButton);
            testWindow.Show();
            Application.Current.MainWindow.Close();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
