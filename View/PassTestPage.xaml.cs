using System.Windows;
using generator.Helpers;
using generator.Model;

namespace generator;

public partial class PassTestPage
{
    private readonly List<Test>? _test;
    private int _currentQuestion;
    private int _countOfCorrectAnswers;
    public PassTestPage()
    {
        InitializeComponent();
        _test = Serializer.Deserialize();
        RefreshPage();
    }

    private void NextButton()
    {
        if (_test != null && _currentQuestion < _test.Count)
        {
            _currentQuestion++;
            if (_currentQuestion == _test.Count)
            {
                var result = MessageBox.Show($"Вы прошли тест. " +
                                             $"Число правильных ответов: {_countOfCorrectAnswers} из {_test.Count}.",
                    "Хотите завершить работу программы?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Environment.Exit(0);
                        break;
                    case MessageBoxResult.No:
                        _currentQuestion = 0;
                        break;
                    case MessageBoxResult.None:
                        break;
                    case MessageBoxResult.OK:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default: throw new ArgumentOutOfRangeException();
                }
            }
        }
        
        RefreshPage();
    }

    private async void RightAnswerCheck(int answer)
    {
        if (_test is not { Count: > 0 } || answer < 0 || answer >= 3) return;
        var rightAnswer = _test[_currentQuestion].RightAnswer;
        if (rightAnswer == (RightAnswer)answer)
        {
            AnswerBlock.Text = "Правильный ответ!";
            _countOfCorrectAnswers++;
            await Task.Delay(1200);
            NextButton();
        }
        else
        {
            AnswerBlock.Text = "Неправильный ответ!";
            await Task.Delay(1200);
            NextButton();
        }
    }

    private void RefreshPage()
    {
        if (_test == null || _currentQuestion >= _test.Count) return;
        AnswerBlock.Text = string.Empty;
        NameTextBlock.Text = _test?[_currentQuestion].Name;
        FirstButton.Content = _test?[_currentQuestion].FirstAnswer;
        ThirdButton.Content = _test?[_currentQuestion].ThirdAnswer;
        SecondButton.Content = _test?[_currentQuestion].SecondAnswer;
        DescriptionTextBlock.Text = _test?[_currentQuestion].Description;
    }

    private void FirstButton_OnClick(object sender, RoutedEventArgs e)
    {
        RightAnswerCheck(0);
    }

    private void SecondButton_OnClick(object sender, RoutedEventArgs e)
    {
        RightAnswerCheck(1);
    }

    private void ThirdButton_OnClick(object sender, RoutedEventArgs e)
    {
        RightAnswerCheck(2);
    }
}