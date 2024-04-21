using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using generator.Helpers;
using generator.Model;
using generator.ViewModels.Helpers;

namespace generator.ViewModels
{
    internal class EditTestViewModel : BindingHelper
    {
        private ObservableCollection<Test> _tests;
        private Test _lastTest;
        public ObservableCollection<Test> Tests
        {
            get => _tests;
            set
            {
                _tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }

        public EditTestViewModel()
        {
            Tests = new ObservableCollection<Test>();
            LoadTests();
        }

        public ICommand SortingCommand => new BindableCommand(AddNewTest);
        public ICommand DeleteCommand => new BindableCommand(DeleteTest);
        public ICommand UpdateCommand => new BindableCommand(UpdateTests);

        private void LoadTests()
        {
            var loadedTests = Serializer.Deserialize();
            if (loadedTests == null || loadedTests.Count == 0)
            {
                var newTest = new Test("", "", "", "", "", RightAnswer.FirstAnswer, new ObservableCollection<Test>());
                Tests.Add(newTest);
                Serializer.Serialize(Tests.ToList());
            }
            else
            {
                foreach (var test in loadedTests)
                {
                    Tests.Add(test);
                }
            }
        }

        private void DeleteTest(object parameter)
        {
            if (parameter is KeyEventArgs e)
            {
                if (e.Source is DataGrid dataGrid && dataGrid.SelectedItem is Test testToRemove)
                {
                    Tests.Remove(testToRemove);
                    Serializer.Serialize(Tests.ToList());
                }
            }
        }

        private void AddNewTest(object parameter)
        {
            if (_lastTest == null || string.IsNullOrWhiteSpace(_lastTest.Name) ||
                string.IsNullOrWhiteSpace(_lastTest.Description) ||
                string.IsNullOrWhiteSpace(_lastTest.FirstAnswer) ||
                string.IsNullOrWhiteSpace(_lastTest.SecondAnswer) ||
                string.IsNullOrWhiteSpace(_lastTest.ThirdAnswer))
            {
                var newTest = new Test("", "", "", "", "", RightAnswer.FirstAnswer, new ObservableCollection<Test>());
                Tests.Add(newTest);
                Serializer.Serialize(Tests.ToList());
            }
        }

        private void UpdateTests(object parameter)
        {
            Serializer.Serialize(Tests.ToList());
        }
    }
}
