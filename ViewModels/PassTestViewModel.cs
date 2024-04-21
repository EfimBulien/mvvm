using System.Windows;
using generator.Helpers;
using System.Windows.Input;
using generator.Model;
using generator.ViewModels.Helpers;
using System.Collections.ObjectModel;

namespace generator
{
    internal class PassTestViewModel : BindingHelper
    {
        private readonly ObservableCollection<Test> _test;
        private int _currentQuestion;
        private int _countOfCorrectAnswers;
        private string _answerBlockText;
        public Test CurrentTest => _test[_currentQuestion];

        public string AnswerBlockText
        {
            get => _answerBlockText;
            set
            {
                _answerBlockText = value;
                OnPropertyChanged(nameof(AnswerBlockText));
            }
        }

        public PassTestViewModel()
        {
            _test = Serializer.Deserialize();
            RefreshPage();
            FirstAnswerCommand = new BindableCommand(FirstAnswerCommandExecute);
            SecondAnswerCommand = new BindableCommand(SecondAnswerCommandExecute);
            ThirdAnswerCommand = new BindableCommand(ThirdAnswerCommandExecute);
        }

        public ICommand FirstAnswerCommand { get; }
        public ICommand SecondAnswerCommand { get; }
        public ICommand ThirdAnswerCommand { get; }

        private async void RightAnswerCheck(int answer)
        {
            if (_test == null || answer < 0 || answer >= 3) return;
            var rightAnswer = _test[_currentQuestion].RightAnswer;
            if (rightAnswer == (RightAnswer)answer)
            {
                AnswerBlockText = "Правильный ответ!";
                _countOfCorrectAnswers++;
                await Task.Delay(1200);
                NextButton();
            }
            else
            {
                AnswerBlockText = "Неправильный ответ!";
                await Task.Delay(1200);
                NextButton();
            }
        }

        private void NextButton()
        {
            if (_test != null && _currentQuestion < _test.Count - 1)
            {
                _currentQuestion++;
            }
            else
            {
                var result = MessageBox.Show($"Вы прошли тест. "
                    + $"Число правильных ответов: {_countOfCorrectAnswers} из {_test.Count}.",
                    "Хотите завершить работу программы?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    _currentQuestion = 0;
                }
            }

            RefreshPage();
        }

        private void RefreshPage()
        {
            if (_test == null || _currentQuestion >= _test.Count) return;
            AnswerBlockText = string.Empty;
            OnPropertyChanged(nameof(CurrentTest));
        }

        private void FirstAnswerCommandExecute(object obj)
        {
            RightAnswerCheck(0);
        }

        private void SecondAnswerCommandExecute(object obj)
        {
            RightAnswerCheck(1);
        }

        private void ThirdAnswerCommandExecute(object obj)
        {
            RightAnswerCheck(2);
        }
    }
}
