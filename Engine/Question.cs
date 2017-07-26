using System;
using System.Collections.Generic;
using GuessingGame.EngineApi;

namespace GuessingGame.Engine
{
    public class Question : IQuestion
    {
        public List<string> SubjectNames { get; private set; }

        public string Text { get; }

        public Question(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            Text = text;
            SubjectNames = new List<string>();
        }
    }
}
