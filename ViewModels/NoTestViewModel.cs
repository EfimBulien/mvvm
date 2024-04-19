using generator.ViewModels.Helpers;

namespace generator.ViewModels
{
    internal class NoTestViewModel : BindingHelper
    {
        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public NoTestViewModel() 
        {
            Message = "Теста пока нет";
        }
    }
}
