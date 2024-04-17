using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using QuickPicSurvey.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Infrastructure
{
    internal class QuickPicSurveySQLRepository : IQuickPicSurveyRepository
    {
        private readonly IDbContextFactory<QuickPicSurveyContext> _dbContextFactory;
        public QuickPicSurveySQLRepository(IDbContextFactory<QuickPicSurveyContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async  Task<List<Question>> GetAllQuestions()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Questions.ToListAsync();
            }

        }
        public async Task<List<RespondentResult>> GetRespondentSurveyResults(int respondentId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.RespondentResults.
                    Include(x=>x.Question).
                    Where(x=>x.Respondent.Id==respondentId).ToListAsync();
            }
        }
        public async Task<Question> GetQuestion(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Questions.FindAsync(id);
            }

        }

        public async Task<List<Objective>> GetAllObjectives()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Objectives.Include(x=>x.Question).ToListAsync();
            }

        }
        public async Task<Objective> GetQuestionObjective(int questionId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Objectives.FirstOrDefaultAsync(x => x.Question.Id == questionId);
            }

        }

        public async Task<List<RespondentResult>> GetAllRespondentResults()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.RespondentResults.Include(x => x.Question).Include(x => x.Question).ToListAsync();
            }

        }

        public async Task<Respondent> GetRespondent(int respondentId)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Respondents.FindAsync(respondentId);
            }
        }

        public async Task<List<RespondentResult>> SaveSurveyResults(List<RespondentResult> respondentResults)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                foreach (var result in respondentResults)
                {
                    context.Entry(result.Question).State = EntityState.Unchanged;
                    context.Entry(result.Respondent).State = EntityState.Unchanged;
                }
               await context.RespondentResults.AddRangeAsync(respondentResults);
               await context.SaveChangesAsync();
            }

            return respondentResults;
        }
    }
}
