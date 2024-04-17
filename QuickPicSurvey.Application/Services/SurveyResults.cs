using Microsoft.EntityFrameworkCore;
using QuickPicSurvey.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Application.Services
{
    public class SurveyResults : ISurveyResults
    {
        IQuickPicSurveyRepository _quickPicSurveyRepository;
        public SurveyResults(IQuickPicSurveyRepository quickPicSurveyRepository)
        {
            _quickPicSurveyRepository = quickPicSurveyRepository;
        }


        public async Task<List<SurveyResult>> GetSurveyResults()
        {


            List<SurveyResult> resultsList = new();

            var questions = await _quickPicSurveyRepository.GetAllQuestions();
            var objectives = await _quickPicSurveyRepository.GetAllObjectives();
            var respondentResults = await _quickPicSurveyRepository.GetAllRespondentResults();

            if (respondentResults.Count > 0)
            {
                foreach (var question in questions)
                {
                    var objectiveQuestion = objectives.FirstOrDefault(x => x.Question.Id == question.Id);
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

                    if (surveyResult.RespondentsWeight <= surveyResult.ManagersWeight)
                        surveyResult.Accuracy = Math.Round((surveyResult.RespondentsWeight / surveyResult.ManagersWeight) * 100, 2);
                    else
                        surveyResult.Accuracy = (100 - Math.Round((surveyResult.ManagersWeight / surveyResult.RespondentsWeight) * 100, 2)) * -1;

                    resultsList.Add(surveyResult);

                }
            }

            return resultsList;

        }
    }
}
