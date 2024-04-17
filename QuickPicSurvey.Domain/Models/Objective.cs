using System;
using System.Collections.Generic;
using System.Text;

namespace QuickPicSurvey.Domain.Models
{
    public class Objective
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public int Expectation { get; set; }
    }
}
