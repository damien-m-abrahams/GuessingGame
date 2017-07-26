namespace GuessingGame.SubjectApi
{
    public class Fact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string QuestionPattern { get; set; } // Convention is that QuestionPattern will have Name and Value placeholders
    }
}
