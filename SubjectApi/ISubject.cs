using System.Collections.Generic;

namespace GuessingGame.SubjectApi
{
    /// <summary>The subject of the game</summary>
    /// <remarks>Each subject has associated facts about itself</remarks>
    public interface ISubject
    {
        int Id { get; set; }

        string Name { get; set; }

        string AnswerPattern { get; set; } // Convention is that AnswerPattern will have a Name placeholder

        IEnumerable<Fact> Facts { get; set; }
    }
}
