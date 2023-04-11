using System;
using System.Collections.Generic;

#nullable disable

namespace StudProject.Models
{
    public partial class TheSubject
    {
        public TheSubject()
        {
            Questions = new HashSet<Question>();
            Tests = new HashSet<Test>();
        }

        public int Id { get; set; }
        public string NameOfSubject { get; set; }
        public int? TeacherID { get; set; }       
        
        public int? Groupe { get; set; }

        public virtual Teacher TeacherNavigation { get; set; }
        public virtual Groupe GroupeNavigation { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
    }
}
