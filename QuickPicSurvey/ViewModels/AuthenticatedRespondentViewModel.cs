namespace QuickPicSurvey.ViewModels
{
    public class AuthenticatedRespondentViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}
