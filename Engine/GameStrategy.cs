using System;
using System.Collections.Generic;
using System.Linq;
using GuessingGame.EngineApi;
using GuessingGame.SubjectApi;

namespace GuessingGame.Engine
{
    public class GameStrategy : IGameStrategy
    {
        private List<Question> questions = new List<Question>();

        private Question currentQuestion;

        private readonly Random random = new Random();

        private ISubject selectedSubjectAnswer;

        private List<ISubject> remainingSubjects;

        public IEnumerable<ISubject> AllSubjects { get; set; } = new ISubject[0];

        public IEnumerable<ISubject> PossibleSubjects()
        {
            remainingSubjects = new List<ISubject>(AllSubjects);
            CreateQuestions(remainingSubjects);

            return AllSubjects;
        }

        public void SelectedSubject(ISubject subject)
        {
            selectedSubjectAnswer = subject;
        }

        public IQuestion Question()
        {
            if (questions.Any()) {
                var index = random.Next(0, questions.Count - 1);
                currentQuestion = questions[index];
            } else {
                currentQuestion = null;
            }

            return currentQuestion;
        }

        public void Answer(bool affirmative)
        {
            if (currentQuestion != null) {
                if (affirmative) {
					// TODO: Facts need to be removed from the game when they are discovered to be true or false
					var newRemainingSubjects = currentQuestion.SubjectNames
                        .Select(name => remainingSubjects.FirstOrDefault(subject => subject.Name == name))
                        .Where(subject => subject != null).ToList();
                    remainingSubjects = newRemainingSubjects;
                } else {
                    foreach (var name in currentQuestion.SubjectNames) {
                        remainingSubjects.RemoveAll(subject => subject.Name == name);
                    }
                }
                // Potentially expensive call if there is large number of subjects
                CreateQuestions(remainingSubjects);
            }
        }

        public IAnswer CalculatedSubject()
        {
            IAnswer result = null;

            if (selectedSubjectAnswer != null && remainingSubjects != null) {
                var firstRemainingSubject = remainingSubjects.First();
				// Scenarios may arise where a specific answer cannot be determined based on the logic in this strategy
                if (firstRemainingSubject.Name == selectedSubjectAnswer.Name) {
                    var text = string.Format(firstRemainingSubject.AnswerPattern, firstRemainingSubject.Name);
                    result = new Answer(text);
                }
            }

            return result;
        }

        private void CreateQuestions(IEnumerable<ISubject> subjects)
        {
            questions = new List<Question>();
            foreach (var subject in subjects) {
                foreach (var fact in subject.Facts) {
                    var text = string.Format(fact.QuestionPattern, fact.Name, fact.Value);
                    var question = questions.FirstOrDefault(q => q.Text == text);
                    if (question == null) {
                        question = new Question(text);
                        questions.Add(question);
                    }
                    question.SubjectNames.Add(subject.Name);
                }
            }
        }
    }
}
