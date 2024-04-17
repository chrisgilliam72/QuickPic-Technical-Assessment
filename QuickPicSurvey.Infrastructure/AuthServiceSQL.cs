using Microsoft.EntityFrameworkCore;
using QuickPicSurvey.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Infrastructure
{
    public class AuthServiceSQL : IAuthenticationService
    {
        private readonly IDbContextFactory<QuickPicSurveyContext> _dbContextFactory;
        public AuthServiceSQL(IDbContextFactory<QuickPicSurveyContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Respondent> AuthenticateRespondent(string username, string password)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var respondent= await context.Respondents.FirstOrDefaultAsync(x=>x.Username.ToLower() == username.ToLower());
                return respondent != null && respondent.Password == password ?  respondent:null;
            }
        }
    }
}
