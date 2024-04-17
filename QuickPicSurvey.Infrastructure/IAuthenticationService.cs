using QuickPicSurvey.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Infrastructure
{
    public interface IAuthenticationService
    {
        Task<Respondent> AuthenticateRespondent(String username, String password);
    }
}
