using System;
using System.Collections.Generic;
using GuessingGame.SubjectApi;

namespace GuessingGame.Subjects
{
    public class Animal : ISubject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AnswerPattern { get; set; }

        public IEnumerable<Fact> Facts { get; set; }
    }
}
