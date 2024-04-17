using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Application
{
    //public record SurveyResult (String Question, decimal RespondentsWeight, decimal ManagersWeight, decimal ExpectationGap, decimal Accuracy);
    public class SurveyResult
    {
        public string Question { get; set; } = string.Empty;
        public decimal RespondentsWeight { get; set; }
        public decimal ExpectationGap { get; set; }
        public decimal Accuracy { get; set; }
        public decimal ManagersWeight { get; set; }

        public bool BelowExpection => Accuracy < 0;
    }
}
