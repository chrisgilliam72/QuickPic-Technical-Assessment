namespace QuickPicSurvey.ViewModels
{
    public class SurveyViewModel
    { 
        public List<SurveyQuestionViewModel> Questions { get; set; } = new List<SurveyQuestionViewModel>();

        public bool IsValid()
        {
            if (Questions.Count() == 0)
                return true;

            bool AllQuestionsValid = Questions.All(x => x.IsValid);
            int QuestionSum = Questions.Sum(x => x.Answer);

            return  AllQuestionsValid&& QuestionSum ==100;
        }
    }
}
