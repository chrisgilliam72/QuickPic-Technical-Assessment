using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickPicSurvey.Domain.Models
{
    public class Respondent
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
