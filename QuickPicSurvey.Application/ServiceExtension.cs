using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickPicSurvey.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Application
{
    public static class ServiceExtensions
    {
   
        public static IServiceCollection AddQuickPikSurveyApplication(this IServiceCollection services)
        {

            services.AddScoped<ISurveyResults, SurveyResults>();
            return services;
        }

    }
}
