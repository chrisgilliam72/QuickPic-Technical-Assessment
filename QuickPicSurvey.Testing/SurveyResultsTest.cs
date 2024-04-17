using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using QuickPicSurvey.Application;
using QuickPicSurvey.Application.Services;
using QuickPicSurvey.Domain.Models;
using QuickPicSurvey.Infrastructure;

namespace QuickPicSurvey.Testing
{
    public class Tests
    {
        private DbContextOptions<QuickPicSurveyContext> _options;

        [SetUp]
        public void Setup()
        {
            void AddRespondentQuestions(Question question, int averageValue, QuickPicSurveyContext context)
            {
               var respondents= context.Respondents.ToList();
               foreach(var respondent in respondents)
                {
                    context.RespondentResults.Add(new RespondentResult()
                    {
                        Question = question,
                        Answer = averageValue,
                        Respondent = respondent,
                    });


                }
            }
               
            _options = new DbContextOptionsBuilder<QuickPicSurveyContext>()
            .UseInMemoryDatabase(databaseName: "QuickPicSurvey")
            .Options;
            using (var context = new QuickPicSurveyContext(_options))
            {
                var question1 = new Question { Id = 1, Text = "Internal Meetings" };
                var question2 = new Question { Id = 2, Text = "Client Meetings" };
                var question3 = new Question { Id = 3, Text = "Emails & Phone / Skype calls" };
                var question4 = new Question { Id = 4, Text = "Research" };
                var question5 = new Question { Id = 5, Text = "DB Design" };
                var question6 = new Question { Id = 6, Text = "Architecture Design and Planning" };
                var question7 = new Question { Id = 7, Text = "Back-end Development" };
                var question8 = new Question { Id = 8, Text = "Front-end Development" };
                var question9 = new Question { Id = 9, Text = "Integration" };
                var question10 = new Question { Id = 10, Text = "Testing" };

                var respondentJohn = new Respondent { Id = 1, Username = "u1", Firstname = "John", Lastname = "Smith", Password = "password" };
                var respondentSusan = new Respondent { Id = 2, Username = "u2", Firstname = "Susan", Lastname = "Birnam", Password = "password" };
                var respondentSteve = new Respondent { Id = 3, Username = "u3", Firstname = "Carter", Lastname = "Flamings", Password = "password" };
                var respondentElrond = new Respondent { Id = 4, Username = "u4", Firstname = "Elrond", Lastname = "Raven", Password = "password" };
                var respondentFrodo = new Respondent { Id = 5, Username = "u5", Firstname = "Frodo", Lastname = "Smitherns", Password = "password" };

                context.Questions.Add(question1);
                context.Questions.Add(question2);
                context.Questions.Add(question3);
                context.Questions.Add(question4);
                context.Questions.Add(question5);
                context.Questions.Add(question6);
                context.Questions.Add(question7);
                context.Questions.Add(question8);
                context.Questions.Add(question9);
                context.Questions.Add(question10);
                context.SaveChanges();

                context.Respondents.Add(respondentJohn);
                context.Respondents.Add(respondentSusan);
                context.Respondents.Add(respondentSteve);
                context.Respondents.Add(respondentElrond);
                context.Respondents.Add(respondentFrodo);
                context.SaveChanges();

                context.Objectives.Add(new Objective { Id = 1, Question = question1, Expectation = 8 });
                context.Objectives.Add(new Objective { Id = 2, Question = question2, Expectation = 8 });
                context.Objectives.Add(new Objective { Id = 3, Question = question3, Expectation = 5 });
                context.Objectives.Add(new Objective { Id = 4, Question = question4, Expectation = 5 });
                context.Objectives.Add(new Objective { Id = 5, Question = question5, Expectation = 2 });
                context.Objectives.Add(new Objective { Id = 6, Question = question6, Expectation = 5 });
                context.Objectives.Add(new Objective { Id = 7, Question = question7, Expectation = 30 });
                context.Objectives.Add(new Objective { Id = 8, Question = question8, Expectation = 22 });
                context.Objectives.Add(new Objective { Id = 9, Question = question9, Expectation = 5 });
                context.Objectives.Add(new Objective { Id = 10, Question = question10, Expectation = 10 });
                context.SaveChanges();

                AddRespondentQuestions(question1, 8, context);
                AddRespondentQuestions(question2, 10, context);
                AddRespondentQuestions(question3, 5, context);
                AddRespondentQuestions(question4, 10, context);
                AddRespondentQuestions(question5, 5, context);
                AddRespondentQuestions(question6, 8, context);
                AddRespondentQuestions(question7, 30, context);
                AddRespondentQuestions(question8, 5, context);
                AddRespondentQuestions(question9, 10, context);
                AddRespondentQuestions(question10, 9, context);
                context.SaveChanges();
            }

        }

        [Test]
        public void Test()
        {
            // to test with I used the values given in the assesmemt PDF and test the accuracy comes out the same.
            List<SurveyResult> GetSurveyResults(QuickPicSurveyContext context)
            {


                List<SurveyResult> resultsList = new();

                var questions =  context.Questions.ToList();
                var objectives = context.Objectives.ToList();
                var respondentResults =  context.RespondentResults.Include(x=>x.Question).ToList();

                if (respondentResults.Count > 0)
                {
                    foreach (var question in questions)
                    {
                        var objectiveQuestion = objectives.FirstOrDefault(x=>x.Question.Id==question.Id);
                        var managersWeight = objectiveQuestion.Expectation;

                        var sumAnswers = respondentResults.Where(x => x.Question.Id == question.Id).Sum(x => x.Answer);
                        var questionsTotal = respondentResults.Where(x => x.Question.Id == question.Id).Count();

                        var weighting = sumAnswers / questionsTotal;
                        var surveyResult = new SurveyResult()
                        {
                            Question = question.Text,
                            RespondentsWeight = weighting,
                            ManagersWeight = managersWeight,
                            ExpectationGap = managersWeight - weighting
                        };

                        if (surveyResult.RespondentsWeight<=surveyResult.ManagersWeight)
                            surveyResult.Accuracy = Math.Round((surveyResult.RespondentsWeight / surveyResult.ManagersWeight) * 100, 2);
                        else
                            surveyResult.Accuracy = (100-Math.Round((surveyResult.ManagersWeight / surveyResult.RespondentsWeight) * 100, 2))*-1;

                        resultsList.Add(surveyResult);

                    }
                }

                return resultsList;

            }
            using (var context = new QuickPicSurveyContext(_options))
            {

                var surveyResults = GetSurveyResults(context);
                Assert.AreEqual(surveyResults[0].Accuracy, 100);
                Assert.AreEqual(surveyResults[1].Accuracy, -20);
                Assert.AreEqual(surveyResults[2].Accuracy, 100);
                Assert.AreEqual(surveyResults[3].Accuracy, -50);
                Assert.AreEqual(surveyResults[4].Accuracy, -60);
                Assert.AreEqual(surveyResults[5].Accuracy, -37.5);
                Assert.AreEqual(surveyResults[6].Accuracy, 100);
                Assert.AreEqual(surveyResults[7].Accuracy, 22.73);
                Assert.AreEqual(surveyResults[8].Accuracy, -50);
                Assert.AreEqual(surveyResults[9].Accuracy, 90);
            }
         
        }
    }
}



    