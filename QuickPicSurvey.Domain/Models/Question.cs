using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuickPicSurvey.Domain.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
