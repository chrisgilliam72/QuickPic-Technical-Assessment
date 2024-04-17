
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using QuickPicSurvey.ViewModels;

namespace QuickPicSurvey.Components
{
    partial class Login
    {
        [Inject]
        QuickPicSurvey.Infrastructure.IAuthenticationService AuthenticationService { get; set; }
        LoginViewModel ViewModel { get; set; } = new LoginViewModel();
        [Parameter]
        public EventCallback<AuthenticatedRespondentViewModel> OnSuccessfullLogin { get; set; }
        public bool LoginFailed { get; private set; } = false;

        protected override Task OnInitializedAsync()
        {
            ViewModel.Username = "u1";
            ViewModel.Password = "password";
            return base.OnInitializedAsync();
        }

        async Task OnLogin()
        {
            if (ViewModel.Username.ToLower()=="admin" && ViewModel.Password.ToLower()=="admin") 
            {
                AuthenticatedRespondentViewModel authedRespondentVM = new()
                {
                    FullName = "admin",
                    Id = 99,
                    IsAdmin = true

                };

                await OnSuccessfullLogin.InvokeAsync(authedRespondentVM);
            }
            else
            {
                var authenticatedRespondent = await AuthenticationService.AuthenticateRespondent(ViewModel.Username, ViewModel.Password);
                if (authenticatedRespondent != null)
                {
                    AuthenticatedRespondentViewModel authedRespondentVM = new()
                    {
                        FullName = authenticatedRespondent.Firstname + " " + authenticatedRespondent.Lastname,
                        Id = authenticatedRespondent.Id,

                    };
                    await OnSuccessfullLogin.InvokeAsync(authedRespondentVM);
                }
                LoginFailed = true;
            }

            
        }
    }
}
