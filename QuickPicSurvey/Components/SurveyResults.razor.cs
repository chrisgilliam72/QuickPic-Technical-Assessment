using Microsoft.AspNetCore.Components;
using QuickPicSurvey.Application;
using QuickPicSurvey.Application.Services;

namespace QuickPicSurvey.Components
{
    partial class SurveyResults
    {
        [Inject]
        ISurveyResults SurveyResultsService { get; set; }
        List<SurveyResult> SurveyResultsList { get; set; }
        protected override async Task OnInitializedAsync()
        {
            //await Task.Run(SimulateDbLoading);
            SurveyResultsList =await SurveyResultsService.GetSurveyResults();
        }

        private void SimulateDbLoading()
        {
            System.Threading.Thread.Sleep(20000);
        }
    }
}
