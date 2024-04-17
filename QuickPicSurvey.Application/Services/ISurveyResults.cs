using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Application.Services
{
    public interface ISurveyResults
    {
        public Task<List<SurveyResult>> GetSurveyResults();
    }
}
