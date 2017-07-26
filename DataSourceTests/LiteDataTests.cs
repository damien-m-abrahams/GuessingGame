using System;
using System.Collections.Generic;
using System.Linq;
using GuessingGame.Data.Sources;
using GuessingGame.Subjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataSourceTests
{
    [TestClass]
    public class LiteDataTests
    {
        [TestMethod]
        public void LiteDataCanRetrieveDefaultAnimals()
        {
            var defaultAnimals = AnimalFactory.CreateAnimals();
            using (var dataSource = new LiteAnimalData("Animals")) {
                foreach (var subject in defaultAnimals.Subjects) {
                    dataSource.Insert(subject);  
                }
            }

            using (var dataSource = new LiteAnimalData("Animals")) {
                var subjects = dataSource.GetAll().ToArray();

                Assert.IsTrue(subjects.Length == 3);

                // Use String.Comparison methods for case-insensitive assertions
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
}
