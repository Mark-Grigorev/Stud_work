using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class Test
    {
        public int Id { get; set; }
        public int? Teacher { get; set; }
        public int? Subject { get; set; }
        public string NameOfQuestion { get; set; }
        public string CorrectAnswer { get; set; }
        public string FQuest { get; set; }
        public string SQuest { get; set; }
        public string TQuest { get; set; }
        public string FoQuest { get; set; }
        public bool GetTest { get; set; }

        public virtual TheSubject SubjectNavigation { get; set; }
        public virtual Teacher TeacherNavigation { get; set; }
    }
}
