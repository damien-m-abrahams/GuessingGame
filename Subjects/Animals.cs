using System;
using System.Collections.Generic;
using GuessingGame.SubjectApi;

namespace GuessingGame.Subjects
{
    public class Animals
    {
        public IEnumerable<Animal> Subjects { get; private set; }

        public Animals(IEnumerable<Animal> subjects)
        {
            if (subjects == null) throw new ArgumentNullException(nameof(subjects));

            Subjects = subjects;
        }
    }
}
