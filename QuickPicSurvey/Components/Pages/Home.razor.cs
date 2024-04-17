using QuickPicSurvey.ViewModels;

namespace QuickPicSurvey.Components.Pages
{
    partial class Home
    {
        public AuthenticatedRespondentViewModel AuthenticatedRespondentVM { get; set; } = new AuthenticatedRespondentViewModel();
        public bool IsLoggedIn { get; set; } = false;

        public void OnLoggedIn(AuthenticatedRespondentViewModel authenticatedRespondentVM)
        {
            IsLoggedIn = true;
            AuthenticatedRespondentVM = authenticatedRespondentVM;
        }
    }
}
