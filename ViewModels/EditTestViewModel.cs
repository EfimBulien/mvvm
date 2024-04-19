using System.Collections.ObjectModel;
using System.Windows.Input;
using generator.Helpers;
using generator.Model;
using generator.ViewModels.Helpers;

namespace generator.ViewModels
{
    internal class EditTestViewModel : BindingHelper
    {
        private ObservableCollection<Test> _tests;

        public ObservableCollection<Test> Tests
        {
            get => _tests;
            set
            {
                _tests = value;
                OnPropertyChanged(nameof(Tests));
            }
        }

        public ICommand DeleteTestCommand { get; }

        public EditTestViewModel()
        {
            Tests = new ObservableCollection<Test>();
            DeleteTestCommand = new BindableCommand(DeleteTest);
            LoadTests();
        }

        private void LoadTests()
        {
            var loadedTests = Serializer.Deserialize();
            if (loadedTests == null || loadedTests.Count == 0)
            {
                AddNewTest();
            }
            else
            {
                foreach (var test in loadedTests)
                {
                    Tests.Add(test);
                }
            }
        }

        private void AddNewTest()
        {
            var newTest = new Test("", "", "", "", "", RightAnswer.FirstAnswer, new List<Test>());
            Tests.Add(newTest);
            Serializer.Serialize(Tests.ToList());
        }

        private void DeleteTest(object test)
        {
            if (test is Test testToRemove)
            {
                Tests.Remove(testToRemove);
                Serializer.Serialize(Tests.ToList());
            }
        }
    }
}
