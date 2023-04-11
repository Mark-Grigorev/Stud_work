using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class Question
    {
        public int Id { get; set; }
        public string NameOfQuestion { get; set; }
        public string CorrectAnswer { get; set; }
        public int? Teacher { get; set; }
        public int? TheSubject { get; set; }

        public virtual Teacher TeacherNavigation { get; set; }
        public virtual TheSubject TheSubjectNavigation { get; set; }
    }
}
