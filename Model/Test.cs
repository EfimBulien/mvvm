namespace generator.Model;

public enum RightAnswer
{
    FirstAnswer,
    SecondAnswer,
    ThirdAnswer
}
public class Test
{
    public Test(string name, string description, string firstAnswer, string secondAnswer, string thirdAnswer,
        RightAnswer rightAnswer, List<Test> test)
    {
        Name = name;
        Description = description;
        FirstAnswer = firstAnswer;
        SecondAnswer = secondAnswer;
        ThirdAnswer = thirdAnswer;
        RightAnswer = rightAnswer;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string FirstAnswer { get; set; }
    public string SecondAnswer { get; set; }
    public string ThirdAnswer { get; set; }
    public RightAnswer RightAnswer { get; set; }
}