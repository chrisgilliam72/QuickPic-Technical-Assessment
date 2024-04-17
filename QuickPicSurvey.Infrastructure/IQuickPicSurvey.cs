using QuickPicSurvey.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Infrastructure
{
    public interface IQuickPicSurveyRepository
    {
        public Task<Question> GetQuestion(int id);
        public Task<List<Question>> GetAllQuestions();
 

        public Task<List<Objective>> GetAllObjectives();
        public Task<Objective> GetQuestionObjective(int questionId);

        public Task<List<RespondentResult>> GetAllRespondentResults();
        public Task<Respondent> GetRespondent(int respondentId);

        public Task<List<RespondentResult>> GetRespondentSurveyResults(int respondentId);
        public Task<List<RespondentResult>> SaveSurveyResults(List<RespondentResult> respondentResults);
    }
}
