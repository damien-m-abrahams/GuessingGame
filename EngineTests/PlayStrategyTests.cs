using System;
using System.Linq;
using System.Security.Permissions;
using GuessingGame.Engine;
using GuessingGame.Subjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EngineTests
{
	// TODO: These tests don't work because questions facts need to be removed from the game when they are discovered to be true or false

    [TestClass]
    public class PlayStrategyTests
    {
        [TestMethod]
        public void NegativeResponseToQuestionsAboutShark()
        {
            var animals = AnimalFactory.CreateAnimals();

            var sut = new GameStrategy {AllSubjects = animals.Subjects};

            var possibleSubjects = sut.PossibleSubjects().ToArray();
            Assert.IsTrue(possibleSubjects.Length == 3);

            sut.SelectedSubject(possibleSubjects[1]);

			var proceed = true;
			do {
				var question = sut.Question();
				if (question != null) {
					sut.Answer(false);
				} else {
					proceed = false;
				}
			} while (proceed);

            // Answering a question as false is sometimes an incorrect response meaning the system can't determine an answer
			// This test is needs to be expanded to answer yes to any questions pretaining to the selected subject
            sut.Answer(false);

            var answer = sut.CalculatedSubject();
            Assert.IsTrue(answer.Text == string.Format(possibleSubjects[0].AnswerPattern, possibleSubjects[0].Name));
        }

        [TestMethod]
        public void PositiveResponseToQuestionsAboutShark()
        {
            var animals = AnimalFactory.CreateAnimals();

            var sut = new GameStrategy { AllSubjects = animals.Subjects };

            var possibleSubjects = sut.PossibleSubjects().ToArray();
            Assert.IsTrue(possibleSubjects.Length == 3);

            sut.SelectedSubject(possibleSubjects[1]);

	        var proceed = true;
	        do {
		        var question = sut.Question();
		        if (question != null) {
			        sut.Answer(true);
		        } else {
			        proceed = false;
		        }
	        } while (proceed);
                       
            var answer = sut.CalculatedSubject();
            Assert.IsTrue(answer.Text == string.Format(possibleSubjects[1].AnswerPattern, possibleSubjects[1].Name));
        }
    }
}
