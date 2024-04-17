using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Infrastructure
{
    public static  class ServiceExtensions
    {

        public static IServiceCollection AddQuickPikSurveyInfrastructure(this IServiceCollection services)
        {

            IConfiguration configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json")
            .Build();
            var dbString = configuration.GetConnectionString("QuickPicSurveyDB");
            services.AddDbContextFactory<QuickPicSurveyContext>(options =>options.UseSqlServer(dbString));
            services.AddScoped<IQuickPicSurveyRepository, QuickPicSurveySQLRepository>();
            services.AddScoped<IAuthenticationService, AuthServiceSQL>();
            return services;
        }

    }
}
