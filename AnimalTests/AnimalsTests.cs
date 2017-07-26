using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuessingGame.Subjects.Tests
{
    [TestClass]
    public class AnimalsTests
    {
        [TestMethod]
        public void DefaultAnimalsExist()
        {
            var sut = AnimalFactory.CreateAnimals();
            var subjects = sut.Subjects.ToArray();

            Assert.IsTrue(subjects.Length == 3);

			Assert.IsTrue(subjects[0].Name == "Lion");
			Assert.IsTrue(subjects[0].AnswerPattern == "{0}?");
			Assert.IsTrue(subjects[0].Facts.Count() == 6);

			Assert.IsTrue(subjects[1].Name == "Shark");
			Assert.IsTrue(subjects[1].AnswerPattern == "{0}?");
			Assert.IsTrue(subjects[1].Facts.Count() == 6);

			Assert.IsTrue(subjects[2].Name == "Human");
			Assert.IsTrue(subjects[2].AnswerPattern == "{0}?");
			Assert.IsTrue(subjects[2].Facts.Count() == 6);
		}
    }
}
