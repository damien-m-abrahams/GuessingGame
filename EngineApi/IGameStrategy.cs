using System.Collections.Generic;
using GuessingGame.SubjectApi;

namespace GuessingGame.EngineApi
{
    public interface IGameStrategy
    {
        IEnumerable<ISubject> AllSubjects { get; set; }

        IEnumerable<ISubject> PossibleSubjects();

        void SelectedSubject(ISubject subject);

        IQuestion Question();

        void Answer(bool affirmative);

        IAnswer CalculatedSubject();
    }
}