// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

using System.Collections.Generic;



namespace ExploreIdentityServer6.Contract.RootListOne
{
    public class Answer
    {
        public int value { get; set; }
        public string label { get; set; }
    }

    public class Question
    {
        public int id { get; set; }
        public string title { get; set; }
        public string question { get; set; }
        public int answerType { get; set; }
        public List<Answer> answers { get; set; }
    }

    public class Datum
    {
        public int id { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public string category { get; set; }
        public string status { get; set; }
        public string label { get; set; }
        public string labelColor { get; set; }
        public string date { get; set; }
        public List<Question> questions { get; set; }
    }

    public class RootListOne
    {
        public bool status { get; set; }
        public List<Datum> data { get; set; }
    }
}

