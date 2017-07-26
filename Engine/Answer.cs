using GuessingGame.EngineApi;

namespace GuessingGame.Engine
{
    public class Answer : IAnswer
    {
        public string Text { get; }

        public Answer(string text)
        {
            Text = text;
        }
    }
}
