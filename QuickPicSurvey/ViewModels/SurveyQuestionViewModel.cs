using System.ComponentModel.DataAnnotations;

namespace QuickPicSurvey.ViewModels
{
    public class SurveyQuestionViewModel
    {

        public int QuestionId { get; set; }

        public string QuestionText { get; set; }

        public bool IsValid =>  Answer>=0 && Answer<=100;
        public bool Invalid => !IsValid;
        public int Answer { get; set; } = 0;

        public string AnswerString
        {
            get => Answer.ToString();
            set
            {
     
                if (int.TryParse(value, out int result))
                {
                    Answer = result;
                }
                else
                {
                    Answer = 0;
                }
            }
        }


    }
}

