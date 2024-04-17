using System.ComponentModel.DataAnnotations;

namespace QuickPicSurvey.Domain.Models
{
    public class RespondentResult
    {
        [Key]
        public int Id { get; set; }
        public int Answer { get; set; }
        public Question Question { get; set; }
        public Respondent Respondent { get; set; }
    }
}
