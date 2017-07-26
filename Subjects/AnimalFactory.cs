using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.SubjectApi;

namespace GuessingGame.Subjects
{
    public static class AnimalFactory
    {
        public static Animals CreateAnimals()
        {
            var subjects = new List<Animal>();
            var lion = new Animal
            {
                Name = "Lion",
                AnswerPattern = "{0}?",
                Facts = new[] {
                    new Fact {
                        Name = "noise",
                        Value = "roar",
                        QuestionPattern = "{0}: {1}"
                    },
                    new Fact {
                        Name = "legs",
                        Value = "four",
                        QuestionPattern = "{0}: {1}"
                    },
                    new Fact {
                        Name = "teeth",
                        Value = "sharp",
                        QuestionPattern = "{0}: {1}"
                    },
                    new Fact {
                        Name = "hair",
                        Value = "yellow",
                        QuestionPattern = "{0}: {1}"
                    },
                    new Fact {
                        Name = "family",
                        Value = "large",
                        QuestionPattern = "{0}: {1}"
                    },
					new Fact {
						Name = "habitat",
						Value = "grasslands",
						QuestionPattern = "{0}: {1}"
					}
                }
            };
            subjects.Add(lion);

	        var shark = new Animal {
		        Name = "Shark",
		        AnswerPattern = "{0}?",
		        Facts = new[] {
			        new Fact {
				        Name = "noise",
				        Value = "none",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "fins",
				        Value = "three",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "teeth",
				        Value = "sharp",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "hair",
				        Value = "none",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "family",
				        Value = "loner",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "habitat",
				        Value = "ocean",
				        QuestionPattern = "{0}: {1}"
			        }
		        }
	        };
			subjects.Add(shark);

			var human = new Animal {
		        Name = "Human",
		        AnswerPattern = "{0}?",
		        Facts = new[] {
			        new Fact {
				        Name = "noise",
				        Value = "talks",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "legs",
				        Value = "two",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "teeth",
				        Value = "blunt",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "hair",
				        Value = "mixed",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "family",
				        Value = "mixed",
				        QuestionPattern = "{0}: {1}"
			        },
			        new Fact {
				        Name = "habitat",
				        Value = "cities",
				        QuestionPattern = "{0}: {1}"
			        }
		        }
	        };
            subjects.Add(human);

            var animals = new Animals(subjects);

            return animals;
        }
    }
}
