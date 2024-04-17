using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QuickPicSurvey.Domain.Models;
using QuickPicSurvey.Infrastructure;
using QuickPicSurvey.ViewModels;
using QuickPicSurvey.Helpers;
namespace QuickPicSurvey.Components
{
    partial class SubmitSurvey 
    {

        [Parameter]
        public int UserId { get; set; }

        SurveyViewModel ViewModel { get; set; } = new SurveyViewModel();
        [Inject]
        IQuickPicSurveyRepository QuickPicSurveyRepository { get; set; }
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public bool IsToastVisible { get; private set; }
        private Toast toastComponent { get; set; } = new Toast();
        public bool ShowToast { get; private set; }
        public bool HasError { get; private set; }
        public String ToastMessage { get; private set; }
        public String ToastTitle { get; private set; }
        private bool SurveyCompleted { get; set; } = false;
        private bool Submitted { get; set; } = false;
        protected async override Task OnInitializedAsync()
        {

            ViewModel.Questions.Clear();
            var surveyResults = await QuickPicSurveyRepository.GetRespondentSurveyResults(UserId);
            if (surveyResults.Any())
            {
                SurveyCompleted = true;
                foreach (var result in surveyResults)
                {
                    var questionVieModel = new SurveyQuestionViewModel
                    {
                        QuestionId = result.Question.Id,
                        QuestionText = result.Question.Text,
                        Answer=result.Answer
                    };

                    ViewModel.Questions.Add(questionVieModel);
                }
            }
            else
            {
                var questions = await QuickPicSurveyRepository.GetAllQuestions();
                var shufffledQuestions = questions.Shuffle();
                foreach (var question in shufffledQuestions)
                {
                    var questionVieModel = new SurveyQuestionViewModel
                    {
                        QuestionId = question.Id,
                        QuestionText = question.Text,
                    };

                    ViewModel.Questions.Add(questionVieModel);
                }

            }

           
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeAsync<object>("showToast");
            ShowToast = false;
            HasError = false;
         
        }
        async Task  OnSubmitSurvey()
        {
           try
            {

                Submitted = true;
                if (ViewModel.IsValid())
                {
                    List<RespondentResult> results = new();
                    var questions = await QuickPicSurveyRepository.GetAllQuestions();
                    var respondent = await QuickPicSurveyRepository.GetRespondent(UserId);
                    if (respondent != null)
                    {
                        foreach (var questionVM in ViewModel.Questions)
                        {
                            var resultQuestion = questions.FirstOrDefault(x => x.Id == questionVM.QuestionId);
                            if (resultQuestion != null)
                            {
                                var respondentResult = new RespondentResult()
                                {
                                    Question = resultQuestion,
                                    Respondent = respondent,
                                    Answer = questionVM.Answer

                                };
                                results.Add(respondentResult);
                            }
                        }
                    }

                    await QuickPicSurveyRepository.SaveSurveyResults(results);
                    ToastMessage = "Your survey has been submitted";
                    ToastTitle = "Success";
                    ShowToast = true;
                    SurveyCompleted = true;
                }

            }
            catch (Exception ex) 
            {
                ToastMessage = "An error has occurred and your survey could not be submitted";
                ToastTitle = "Error";
                HasError= true;
                ShowToast = true;
            }
        }


    }
}
