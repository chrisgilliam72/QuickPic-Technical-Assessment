using Microsoft.EntityFrameworkCore;
using QuickPicSurvey.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPicSurvey.Infrastructure
{
    public class QuickPicSurveyContext : DbContext
    {
        public DbSet<Respondent> Respondents { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<RespondentResult> RespondentResults { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public QuickPicSurveyContext(DbContextOptions<QuickPicSurveyContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var question1 = new Question { Id = 1, Text = "Internal Meetings" };
            var question2 = new Question { Id = 2, Text = "Client Meetings" };
            var question3 = new Question { Id = 3, Text = "Emails & Phone / Skype calls" };
            var question4 = new Question { Id = 4, Text = "Research" };
            var question5 = new Question { Id = 5, Text = "DB Design" };
            var question6 = new Question { Id = 6, Text = "Architecture Design and Planning" };
            var question7 = new Question { Id = 7, Text = "Back-end Development" };
            var question8 = new Question { Id = 8, Text = "Front-end Development" };
            var question9 = new Question { Id = 9, Text = "Integration" };
            var question10 = new Question { Id = 10, Text = "Testing" };

            modelBuilder.Entity<Respondent>().HasData(
                new Respondent { Id = 1, Username = "u1", Firstname = "John", Lastname = "Smith", Password = "password" },
                new Respondent { Id = 2, Username = "u2", Firstname = "Susan", Lastname = "Birnam", Password = "password" },
                new Respondent { Id = 3, Username = "u3", Firstname = "Carter", Lastname = "Flamings", Password = "password" },
                new Respondent { Id = 4, Username = "u4", Firstname = "Elrond", Lastname = "Raven", Password = "password" },
                new Respondent { Id = 5, Username = "u5", Firstname = "Frodo", Lastname = "Smitherns", Password = "password" }
            );

            modelBuilder.Entity<Question>().HasData(
                                question1,
                               question2,
                               question3,
                               question4,
                               question5,
                               question6,
                                question7,
                                question8,
                               question9,
                               question10);

            //not sure how to do this so I manually added these
            //modelBuilder.Entity<Objective>().HasData(
            //    new Objective { Id = 1, Question= question1, Expectation = 8 }
                //new Objective { Id = 2, QuestionId = 2, Expectation = 8 },
                //new Objective { Id = 3, QuestionId = 3, Expectation = 5 },
                //new Objective { Id = 4, QuestionId = 4, Expectation = 5 },
                //new Objective { Id = 5, QuestionId = 5, Expectation = 2 },
                //new Objective { Id = 6, QuestionId = 6, Expectation = 5 },
                //new Objective { Id = 7, QuestionId = 7, Expectation = 30 },
                //new Objective { Id = 8, QuestionId = 8, Expectation = 22 },
                //new Objective { Id = 9, QuestionId = 9, Expectation = 5 },
                //new Objective { Id = 10, QuestionId = 10, Expectation = 10 }
           //);

        }


    }
}
