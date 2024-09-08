using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PTestApp
{
    public class Test
    {
        public string Name {get;set;}
        public List<QuestionClass> Questions { get; set; }
        public List<int> AnswerCost {get;set;}
        public List<TestResult> Results {get;set;}


        public QuestionClass GetNextQuestion(int questionNumber)
        {
            if (questionNumber >= Questions.Count) return null;
            return Questions[questionNumber++];
        }
    }

    public class QuestionClass
    {
        public string Question {get;set;}
        public List<string> Answers {get;set;}
    }

    public class TestResult
    {
        public int From {get;set;}
        public int To {get;set;}
        public string Message {get;set;}
    }
}

